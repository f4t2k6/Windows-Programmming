using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

/// <summary>
/// Lớp quản lý kết nối SQL Server.
/// Tự động ghi log mỗi lần mở/đóng và phát hiện connection leak qua finalizer.
/// Hỗ trợ IDisposable để dùng với using statement.
/// </summary>
class MY_DB : IDisposable
{
    // =============================================
    // KẾT NỐI DATABASE
    // =============================================
    private SqlConnection con = new SqlConnection(
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=myDB;Integrated Security=True"
    );

    /// <summary>Trả về SqlConnection để dùng trực tiếp nếu cần.</summary>
    public SqlConnection conn => con;

    // =============================================
    // TRACKING INSTANCE (dùng cho logging & leak detection)
    // =============================================

    /// <summary>Định danh duy nhất của instance này để theo dõi trong log.</summary>
    private readonly Guid _instanceId = Guid.NewGuid();

    /// <summary>Thời điểm connection được mở (null nếu chưa mở).</summary>
    private DateTime? _openedAt;

    /// <summary>Thông tin caller của lần openConnection() gần nhất.</summary>
    private string _callerInfo = "?";

    private bool _disposed;

    // ─── Mở / Đóng ───────────────────────────────

    /// <summary>
    /// Mở kết nối nếu chưa mở. Tự động ghi log với thông tin caller.
    /// </summary>
    public void openConnection(
        [CallerMemberName] string callerMember = "",
        [CallerFilePath]   string callerFile   = "",
        [CallerLineNumber] int    callerLine    = 0)
    {
        if (con.State == ConnectionState.Closed)
        {
            // Lưu caller info để dùng khi đóng / phát hiện leak
            string fileName = System.IO.Path.GetFileName(callerFile);
            _callerInfo = $"{callerMember} ({fileName}:{callerLine})";
            _openedAt   = DateTime.Now;

            con.Open();
            DbConnectionLogger.LogOpen(_instanceId, _callerInfo);
        }
    }

    /// <summary>
    /// Đóng kết nối nếu đang mở. Tự động ghi log với thời gian sống.
    /// </summary>
    public void closeConnection()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
            DbConnectionLogger.LogClose(_instanceId);
            _openedAt = null;
        }
    }

    // =============================================
    // HELPER METHODS – dùng chung cho mọi class
    // =============================================

    /// <summary>
    /// Thực thi INSERT / UPDATE / DELETE.
    /// Trả về số dòng bị ảnh hưởng, -1 nếu lỗi.
    /// </summary>
    public int ExecuteNonQuery(string sql, SqlParameter[]? parameters = null)
    {
        try
        {
            openConnection();
            using SqlCommand cmd = new SqlCommand(sql, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new Exception("ExecuteNonQuery lỗi: " + ex.Message, ex);
        }
        finally { closeConnection(); }
    }

    /// <summary>
    /// Thực thi SELECT trả về 1 giá trị (COUNT, MAX, …).
    /// Trả về null nếu không có kết quả.
    /// </summary>
    public object? ExecuteScalar(string sql, SqlParameter[]? parameters = null)
    {
        try
        {
            openConnection();
            using SqlCommand cmd = new SqlCommand(sql, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            object? result = cmd.ExecuteScalar();
            return (result == DBNull.Value) ? null : result;
        }
        catch (SqlException ex)
        {
            throw new Exception("ExecuteScalar lỗi: " + ex.Message, ex);
        }
        finally { closeConnection(); }
    }

    /// <summary>
    /// Thực thi SELECT trả về DataTable.
    /// </summary>
    public DataTable GetDataTable(string sql, SqlParameter[]? parameters = null)
    {
        try
        {
            openConnection();
            using SqlCommand cmd = new SqlCommand(sql, con);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        catch (SqlException ex)
        {
            throw new Exception("GetDataTable lỗi: " + ex.Message, ex);
        }
        finally { closeConnection(); }
    }

    // =============================================
    // IDISPOSABLE + FINALIZER (Phát hiện connection leak)
    // =============================================

    /// <summary>
    /// Giải phóng tài nguyên đúng cách — dùng với using statement.
    /// </summary>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Finalizer — chạy khi GC thu hồi object.
    /// Nếu connection vẫn còn mở → báo cáo leak.
    /// </summary>
    ~MY_DB()
    {
        Dispose(disposing: false);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        _disposed = true;

        if (con.State == ConnectionState.Open)
        {
            // Connection bị "quên" chưa đóng → leak!
            DbConnectionLogger.ReportLeak(
                _instanceId,
                _callerInfo,
                _openedAt ?? DateTime.Now);

            try { con.Close(); } catch { /* ignore */ }
        }

        if (disposing)
            con.Dispose();
    }
}