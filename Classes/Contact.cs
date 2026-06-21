using Microsoft.Data.SqlClient;
using System.Data;

/// <summary>
/// Đại diện cho một liên hệ trong bảng [Contact].
/// </summary>
class Contact
{
    // =============================================
    // PROPERTIES
    // =============================================
    public int ID { get; set; }
    public string Fname { get; set; } = string.Empty;
    public string Lname { get; set; } = string.Empty;
    public DateTime? Dob { get; set; }
    public string Gender { get; set; } = string.Empty;
    public int Group_ID { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[]? Pic { get; set; }      // ảnh đại diện (VARBINARY)
    public int UserID { get; set; }

    /// <summary>Họ và tên đầy đủ (tiện hiển thị).</summary>
    public string FullName => $"{Fname} {Lname}".Trim();

    // =============================================
    // PRIVATE – dùng chung trong class
    // =============================================
    private static readonly MY_DB db = new MY_DB();

    // =============================================
    // CREATE
    // =============================================

    /// <summary>
    /// Thêm liên hệ mới.
    /// Trả về ID vừa tạo (IDENTITY), -1 nếu thất bại.
    /// </summary>
    public static int Add(Contact c)
    {
        Validate(c);

        string sql = @"
            INSERT INTO [dbo].[Contact]
                ([Fname],[Lname],[Dob],[Gender],[Group_ID],[Phone],[Address],[Email],[Pic],[UserID])
            OUTPUT INSERTED.ID
            VALUES
                (@fname,@lname,@dob,@gender,@gid,@phone,@address,@email,@pic,@uid)";

        SqlParameter[] prms = BuildParams(c);
        object? result = db.ExecuteScalar(sql, prms);
        return result != null ? Convert.ToInt32(result) : -1;
    }

    // =============================================
    // READ – lấy danh sách
    // =============================================

    /// <summary>
    /// Lấy tất cả liên hệ của user (dùng khi ComboBox chọn "Tất cả nhóm").
    /// </summary>
    public static DataTable GetByUser(int userId)
    {
        string sql = @"
            SELECT c.ID,
                   c.Fname + N' ' + c.Lname AS HoTen,
                   c.Phone, c.Email, c.Gender, c.Dob, c.Address,
                   g.Name AS TenNhom,
                   c.Group_ID, c.Pic
            FROM   [dbo].[Contact] c
            JOIN   [dbo].[Groups]  g ON c.Group_ID = g.ID
            WHERE  c.UserID = @uid
            ORDER BY g.Name, c.Lname";

        SqlParameter[] prms =
        {
            new SqlParameter("@uid", SqlDbType.Int) { Value = userId }
        };

        return db.GetDataTable(sql, prms);
    }

    /// <summary>
    /// Lấy danh bạ theo nhóm cụ thể (dùng cho cboGroup_SelectedIndexChanged).
    /// </summary>
    public static DataTable GetByGroup(int groupId, int userId)
    {
        string sql = @"
            SELECT c.ID,
                   c.Fname + N' ' + c.Lname AS HoTen,
                   c.Phone, c.Email, c.Gender, c.Dob, c.Address,
                   g.Name AS TenNhom,
                   c.Group_ID, c.Pic
            FROM   [dbo].[Contact] c
            JOIN   [dbo].[Groups]  g ON c.Group_ID = g.ID
            WHERE  c.Group_ID = @gid
              AND  c.UserID   = @uid
            ORDER BY c.Lname";

        SqlParameter[] prms =
        {
            new SqlParameter("@gid", SqlDbType.Int) { Value = groupId },
            new SqlParameter("@uid", SqlDbType.Int) { Value = userId }
        };

        return db.GetDataTable(sql, prms);
    }

    /// <summary>
    /// Tìm kiếm theo họ tên hoặc số điện thoại (txtSearch).
    /// groupId = -1 → tìm toàn bộ user, ngược lại tìm trong nhóm.
    /// </summary>
    public static DataTable Search(string keyword, int userId, int groupId = -1)
    {
        string groupFilter = groupId > 0 ? "AND c.Group_ID = @gid" : "";

        string sql = $@"
            SELECT c.ID,
                   c.Fname + N' ' + c.Lname AS HoTen,
                   c.Phone, c.Email, c.Gender, c.Dob, c.Address,
                   g.Name AS TenNhom,
                   c.Group_ID, c.Pic
            FROM   [dbo].[Contact] c
            JOIN   [dbo].[Groups]  g ON c.Group_ID = g.ID
            WHERE  c.UserID = @uid
              AND (c.Fname + N' ' + c.Lname LIKE @kw
                   OR c.Phone LIKE @kw)
              {groupFilter}
            ORDER BY c.Lname";

        var prmList = new System.Collections.Generic.List<SqlParameter>
        {
            new SqlParameter("@uid", SqlDbType.Int)           { Value = userId },
            new SqlParameter("@kw",  SqlDbType.NVarChar, 200) { Value = $"%{keyword.Trim()}%" }
        };

        if (groupId > 0)
            prmList.Add(new SqlParameter("@gid", SqlDbType.Int) { Value = groupId });

        return db.GetDataTable(sql, prmList.ToArray());
    }

    // =============================================
    // READ – lấy 1 bản ghi đầy đủ (cho panel chi tiết)
    // =============================================

    /// <summary>
    /// Lấy thông tin đầy đủ một contact theo ID.
    /// Trả về null nếu không tìm thấy.
    /// </summary>
    public static Contact? GetById(int contactId, int userId)
    {
        string sql = @"
            SELECT * FROM [dbo].[Contact]
            WHERE [ID] = @id AND [UserID] = @uid";

        SqlParameter[] prms =
        {
            new SqlParameter("@id",  SqlDbType.Int) { Value = contactId },
            new SqlParameter("@uid", SqlDbType.Int) { Value = userId }
        };

        DataTable dt = db.GetDataTable(sql, prms);
        if (dt.Rows.Count == 0) return null;

        return MapRow(dt.Rows[0]);
    }

    // =============================================
    // UPDATE
    // =============================================

    /// <summary>
    /// Cập nhật thông tin liên hệ.
    /// Trả về true nếu thành công.
    /// </summary>
    public static bool Edit(Contact c)
    {
        Validate(c);

        string sql = @"
            UPDATE [dbo].[Contact]
            SET  [Fname]    = @fname,
                 [Lname]    = @lname,
                 [Dob]      = @dob,
                 [Gender]   = @gender,
                 [Group_ID] = @gid,
                 [Phone]    = @phone,
                 [Address]  = @address,
                 [Email]    = @email,
                 [Pic]      = @pic
            WHERE [ID]     = @id
              AND [UserID] = @uid";

        // BuildParams tạo param không có @id/@uid, thêm thủ công
        var prmList = new System.Collections.Generic.List<SqlParameter>(BuildParams(c))
        {
            new SqlParameter("@id",  SqlDbType.Int) { Value = c.ID },
            new SqlParameter("@uid", SqlDbType.Int) { Value = c.UserID }
        };

        return db.ExecuteNonQuery(sql, prmList.ToArray()) > 0;
    }

    // =============================================
    // DELETE
    // =============================================

    /// <summary>
    /// Xóa một liên hệ. UserID bắt buộc để chống xóa nhầm.
    /// Trả về true nếu thành công.
    /// </summary>
    public static bool Delete(int contactId, int userId)
    {
        string sql = @"
            DELETE FROM [dbo].[Contact]
            WHERE [ID] = @id AND [UserID] = @uid";

        SqlParameter[] prms =
        {
            new SqlParameter("@id",  SqlDbType.Int) { Value = contactId },
            new SqlParameter("@uid", SqlDbType.Int) { Value = userId }
        };

        return db.ExecuteNonQuery(sql, prms) > 0;
    }

    // =============================================
    // EXPORT
    // =============================================

    /// <summary>
    /// Xuất danh bạ ra file CSV.
    /// groupId = -1 → xuất toàn bộ user.
    /// </summary>
    public static void ExportToCsv(int userId, string filePath, int groupId = -1)
    {
        DataTable dt = groupId > 0
            ? GetByGroup(groupId, userId)
            : GetByUser(userId);

        using var writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8);

        // Header
        writer.WriteLine("ID,Họ tên,Số điện thoại,Email,Giới tính,Ngày sinh,Địa chỉ,Nhóm");

        foreach (DataRow row in dt.Rows)
        {
            string dob = row["Dob"] != DBNull.Value
                ? Convert.ToDateTime(row["Dob"]).ToString("dd/MM/yyyy")
                : "";

            writer.WriteLine(string.Join(",",
                row["ID"],
                $"\"{row["HoTen"]}\"",
                row["Phone"],
                row["Email"],
                row["Gender"],
                dob,
                $"\"{row["Address"]}\"",
                $"\"{row["TenNhom"]}\""
            ));
        }
    }

    // =============================================
    // PRIVATE HELPERS
    // =============================================

    /// <summary>Kiểm tra dữ liệu bắt buộc trước khi ghi DB.</summary>
    private static void Validate(Contact c)
    {
        if (string.IsNullOrWhiteSpace(c.Fname))
            throw new ArgumentException("Họ không được để trống.");
        if (string.IsNullOrWhiteSpace(c.Lname))
            throw new ArgumentException("Tên không được để trống.");
        if (c.Group_ID <= 0)
            throw new ArgumentException("Vui lòng chọn nhóm.");
        if (c.UserID <= 0)
            throw new ArgumentException("UserID không hợp lệ.");
    }

    /// <summary>Tạo mảng SqlParameter dùng chung cho INSERT/UPDATE.</summary>
    private static SqlParameter[] BuildParams(Contact c) =>
    [
        new SqlParameter("@fname",   SqlDbType.NVarChar, 50)  { Value = c.Fname.Trim() },
        new SqlParameter("@lname",   SqlDbType.NVarChar, 50)  { Value = c.Lname.Trim() },
        new SqlParameter("@dob",     SqlDbType.DateTime)       { Value = (object?)c.Dob ?? DBNull.Value },
        new SqlParameter("@gender",  SqlDbType.NVarChar, 10)  { Value = (object?)c.Gender ?? DBNull.Value },
        new SqlParameter("@gid",     SqlDbType.Int)            { Value = c.Group_ID },
        new SqlParameter("@phone",   SqlDbType.NVarChar, 15)  { Value = (object?)c.Phone ?? DBNull.Value },
        new SqlParameter("@address", SqlDbType.NVarChar, 200) { Value = (object?)c.Address ?? DBNull.Value },
        new SqlParameter("@email",   SqlDbType.NVarChar, 100) { Value = (object?)c.Email ?? DBNull.Value },
        new SqlParameter("@pic",     SqlDbType.VarBinary)      { Value = (object?)c.Pic ?? DBNull.Value },
    ];

    /// <summary>Map DataRow → Contact object (dùng cho GetById).</summary>
    private static Contact MapRow(DataRow r) => new Contact
    {
        ID = Convert.ToInt32(r["ID"]),
        Fname = r["Fname"].ToString()!,
        Lname = r["Lname"].ToString()!,
        Dob = r["Dob"] != DBNull.Value ? Convert.ToDateTime(r["Dob"]) : null,
        Gender = r["Gender"].ToString() ?? "",
        Group_ID = Convert.ToInt32(r["Group_ID"]),
        Phone = r["Phone"].ToString() ?? "",
        Address = r["Address"].ToString() ?? "",
        Email = r["Email"].ToString() ?? "",
        Pic = r["Pic"] != DBNull.Value ? (byte[])r["Pic"] : null,
        UserID = Convert.ToInt32(r["UserID"])
    };
}