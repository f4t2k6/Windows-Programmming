using Microsoft.Data.SqlClient;
using System.Data;

/// <summary>
/// Đại diện cho một nhóm danh bạ trong bảng [Groups].
/// </summary>
class Group
{
    // =============================================
    // PROPERTIES
    // =============================================
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UserID { get; set; }

    // =============================================
    // PRIVATE – dùng chung trong class
    // =============================================
    private static readonly MY_DB db = new MY_DB();

    // =============================================
    // CREATE
    // =============================================

    /// <summary>
    /// Thêm nhóm mới cho user hiện tại.
    /// Trả về ID vừa tạo (IDENTITY), -1 nếu thất bại.
    /// </summary>
    public static int AddGroup(string name, int userId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên nhóm không được để trống.");

        if (IsDuplicateName(name, userId))
            throw new InvalidOperationException($"Nhóm \"{name}\" đã tồn tại.");

        string sql = @"
            INSERT INTO [dbo].[Groups] ([Name], [UserID])
            OUTPUT INSERTED.ID
            VALUES (@name, @uid)";

        SqlParameter[] prms =
        {
            new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = name.Trim() },
            new SqlParameter("@uid",  SqlDbType.Int)           { Value = userId }
        };

        object? result = db.ExecuteScalar(sql, prms);
        return result != null ? Convert.ToInt32(result) : -1;
    }

    // =============================================
    // READ
    // =============================================

    /// <summary>
    /// Lấy danh sách nhóm của một user, dùng để bind ComboBox.
    /// </summary>
    public static DataTable GetGroupsByUser(int userId)
    {
        string sql = @"
            SELECT [ID], [Name]
            FROM   [dbo].[Groups]
            WHERE  [UserID] = @uid
            ORDER BY [Name]";

        SqlParameter[] prms =
        {
            new SqlParameter("@uid", SqlDbType.Int) { Value = userId }
        };

        return db.GetDataTable(sql, prms);
    }

    /// <summary>
    /// Lấy thông tin một nhóm theo ID.
    /// Trả về null nếu không tìm thấy.
    /// </summary>
    public static Group? GetById(int groupId)
    {
        string sql = "SELECT [ID],[Name],[UserID] FROM [dbo].[Groups] WHERE [ID]=@id";

        SqlParameter[] prms =
        {
            new SqlParameter("@id", SqlDbType.Int) { Value = groupId }
        };

        DataTable dt = db.GetDataTable(sql, prms);
        if (dt.Rows.Count == 0) return null;

        DataRow r = dt.Rows[0];
        return new Group
        {
            ID = Convert.ToInt32(r["ID"]),
            Name = r["Name"].ToString()!,
            UserID = Convert.ToInt32(r["UserID"])
        };
    }

    // =============================================
    // UPDATE
    // =============================================

    /// <summary>
    /// Đổi tên nhóm. Kiểm tra trùng tên trong cùng user.
    /// Trả về true nếu cập nhật thành công.
    /// </summary>
    public static bool EditGroup(int groupId, string newName, int userId)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Tên nhóm không được để trống.");

        if (IsDuplicateName(newName, userId, excludeId: groupId))
            throw new InvalidOperationException($"Nhóm \"{newName}\" đã tồn tại.");

        string sql = @"
            UPDATE [dbo].[Groups]
            SET    [Name] = @name
            WHERE  [ID]   = @id
              AND  [UserID] = @uid"; //--bảo vệ: chỉ user sở hữu mới sửa được

        SqlParameter[] prms =
        {
            new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = newName.Trim() },
            new SqlParameter("@id", SqlDbType.Int) { Value = groupId },
            new SqlParameter("@uid", SqlDbType.Int) { Value = userId }
        }
        ;

        return db.ExecuteNonQuery(sql, prms) > 0;
    }

    // =============================================
    // DELETE
    // =============================================

    /// <summary>
    /// Xóa nhóm và toàn bộ Contact thuộc nhóm đó.
    /// Thực hiện trong transaction để đảm bảo toàn vẹn.
    /// Trả về true nếu xóa thành công.
    /// </summary>
    public static bool DeleteGroup(int groupId, int userId)
    {
        string sqlContact = @"
            DELETE FROM [dbo].[Contact]
            WHERE  [Group_ID] = @gid AND [UserID] = @uid";

        string sqlGroup = @"
            DELETE FROM [dbo].[Groups]
            WHERE  [ID] = @gid AND [UserID] = @uid";

        SqlParameter[] prmsContact =
        {
            new SqlParameter("@gid", SqlDbType.Int) { Value = groupId },
            new SqlParameter("@uid", SqlDbType.Int) { Value = userId }
        };
        SqlParameter[] prmsGroup =
        {
            new SqlParameter("@gid", SqlDbType.Int) { Value = groupId },
            new SqlParameter("@uid", SqlDbType.Int) { Value = userId }
        };

        db.openConnection();
        SqlTransaction tx = db.conn.BeginTransaction();
        try
        {
            // 1. Xóa Contact thuộc nhóm
            using (SqlCommand cmd1 = new SqlCommand(sqlContact, db.conn, tx))
            {
                cmd1.Parameters.AddRange(prmsContact);
                cmd1.ExecuteNonQuery();
            }
            // 2. Xóa nhóm
            using (SqlCommand cmd2 = new SqlCommand(sqlGroup, db.conn, tx))
            {
                cmd2.Parameters.AddRange(prmsGroup);
                cmd2.ExecuteNonQuery();
            }

            tx.Commit();
            return true;
        }
        catch
        {
            tx.Rollback();
            throw;
        }
        finally { db.closeConnection(); }
    }

    // =============================================
    // VALIDATION – private helper
    // =============================================

    /// <summary>
    /// Kiểm tra tên nhóm có trùng trong cùng user không.
    /// excludeId dùng khi Edit để bỏ qua chính record đang sửa.
    /// </summary>
    private static bool IsDuplicateName(string name, int userId, int excludeId = -1)
    {
        string sql = @"
            SELECT COUNT(*)
            FROM   [dbo].[Groups]
            WHERE  [Name]   = @name
              AND  [UserID] = @uid
              AND  [ID]    <> @excludeId";

        SqlParameter[] prms =
        {
            new SqlParameter("@name",      SqlDbType.NVarChar, 100) { Value = name.Trim() },
            new SqlParameter("@uid",       SqlDbType.Int)           { Value = userId },
            new SqlParameter("@excludeId", SqlDbType.Int)           { Value = excludeId }
        };

        object? result = db.ExecuteScalar(sql, prms);
        return Convert.ToInt32(result) > 0;
    }
}