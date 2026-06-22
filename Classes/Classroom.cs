using Microsoft.Data.SqlClient;
using System.Data;

public class Classroom
{
    MY_DB db = new MY_DB();

    public string MaLop { get; set; }
    public string TenLop { get; set; }
    public int SiSo { get; set; }
    public string GVCN { get; set; }

    // Constructor đầy đủ tham số
    public Classroom(string maLop, string tenLop, int siSo, string gvcn)
    {
        MaLop = maLop;
        TenLop = tenLop;
        SiSo = siSo;
        GVCN = gvcn;
    }

    // Constructor mặc định
    public Classroom() { }

    // -------------------------------------------------------
    // THÊM lớp học
    // -------------------------------------------------------
    public bool AddClassroom()
    {
        try
        {
            db.openConnection();
            string query = "INSERT INTO Classroom VALUES (@ma, @ten, @siso, @gvcn)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@ma", MaLop);
            cmd.Parameters.AddWithValue("@ten", TenLop);
            cmd.Parameters.AddWithValue("@siso", SiSo);
            cmd.Parameters.AddWithValue("@gvcn", (object)GVCN ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }

    // -------------------------------------------------------
    // SỬA lớp học (cập nhật theo khóa chính MaLop)
    // -------------------------------------------------------
    public bool EditClassroom()
    {
        try
        {
            db.openConnection();
            string query = "UPDATE Classroom SET TenLop = @ten, SiSo = @siso, GVCN = @gvcn " +
                           "WHERE MaLop = @ma";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@ma", MaLop);
            cmd.Parameters.AddWithValue("@ten", TenLop);
            cmd.Parameters.AddWithValue("@siso", SiSo);
            cmd.Parameters.AddWithValue("@gvcn", (object)GVCN ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }

    // -------------------------------------------------------
    // XÓA lớp học theo MaLop
    // -------------------------------------------------------
    public static bool DelClassroom(string maLop)
    {
        MY_DB db = new MY_DB();
        try
        {
            db.openConnection();
            string query = "DELETE FROM Classroom WHERE MaLop = @ma";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@ma", maLop);

            return cmd.ExecuteNonQuery() > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }

    // -------------------------------------------------------
    // LẤY DANH SÁCH lớp học (có tìm kiếm, sắp xếp)
    // -------------------------------------------------------
    public static DataTable GetClassrooms(string search = "", string sortBy = "")
    {
        MY_DB db = new MY_DB();
        DataTable dt = new DataTable();
        try
        {
            db.openConnection();
            string query = "SELECT MaLop, TenLop, SiSo, GVCN FROM Classroom WHERE 1=1";

            if (!string.IsNullOrEmpty(search))
                query += " AND (MaLop LIKE @search OR TenLop LIKE @search)";

            switch (sortBy)
            {
                case "Theo Mã Lớp": query += " ORDER BY MaLop ASC"; break;
                case "Theo Tên A-Z": query += " ORDER BY TenLop ASC"; break;
                case "Theo Tên Z-A": query += " ORDER BY TenLop DESC"; break;
                case "Theo Sĩ Số": query += " ORDER BY SiSo DESC"; break;
                default: query += " ORDER BY MaLop ASC"; break;
            }

            SqlCommand cmd = new SqlCommand(query, db.conn);
            if (!string.IsNullOrEmpty(search))
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        finally { db.closeConnection(); }
    }
}