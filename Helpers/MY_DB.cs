using Microsoft.Data.SqlClient;
using System.Data;

class MY_DB
{
    // =============================================
    // KẾT NỐI DATABASE
    // =============================================
    private SqlConnection con = new SqlConnection(
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=myDB;Integrated Security=True"
    );

    /// <summary>Trả về SqlConnection để dùng trực tiếp nếu cần.</summary>
    public SqlConnection conn => con;

    // ─── Mở / Đóng ───────────────────────────────
    public void openConnection()
    {
        if (con.State == ConnectionState.Closed)
            con.Open();
    }

    public void closeConnection()
    {
        if (con.State == ConnectionState.Open)
            con.Close();
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
}