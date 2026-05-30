using Microsoft.Data.SqlClient;
using System.Data;

public class Course
{
    MY_DB db = new MY_DB();

    public string Mamh { get; set; }
    public string Tenmh { get; set; }
    public int Sotc { get; set; }
    public int Tuan { get; set; }
    public int Hocky { get; set; }
    public string Decription { get; set; }

    // Constructor đầy đủ tham số
    public Course(string mamh, string tenmh, int sotc, int tuan, int hocky, string decription)
    {
        Mamh = mamh;
        Tenmh = tenmh;
        Sotc = sotc;
        Tuan = tuan;
        Hocky = hocky;
        Decription = decription;
    }

    // Constructor mặc định (dùng khi tạo đối tượng rỗng để gọi static method, v.v.)
    public Course() { }

    // -------------------------------------------------------
    // THÊM môn học
    // -------------------------------------------------------
    public bool AddCourse()
    {
        try
        {
            db.openConnection();
            string query = "INSERT INTO Course VALUES (@ma, @ten, @tc, @tuan, @hk, @mota)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@ma",   Mamh);
            cmd.Parameters.AddWithValue("@ten",  Tenmh);
            cmd.Parameters.AddWithValue("@tc",   Sotc);
            cmd.Parameters.AddWithValue("@tuan", Tuan);
            cmd.Parameters.AddWithValue("@hk",   Hocky);
            cmd.Parameters.AddWithValue("@mota", (object)Decription ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }

    // -------------------------------------------------------
    // SỬA môn học (cập nhật theo khóa chính MaMH)
    // -------------------------------------------------------
    public bool EditCourse()
    {
        try
        {
            db.openConnection();
            string query = "UPDATE Course SET TenMH = @ten, SoTC = @tc, Tuan = @tuan, " +
                           "Hky = @hk, Mota = @mota WHERE MaMH = @ma";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@ma",   Mamh);
            cmd.Parameters.AddWithValue("@ten",  Tenmh);
            cmd.Parameters.AddWithValue("@tc",   Sotc);
            cmd.Parameters.AddWithValue("@tuan", Tuan);
            cmd.Parameters.AddWithValue("@hk",   Hocky);
            cmd.Parameters.AddWithValue("@mota", (object)Decription ?? DBNull.Value);

            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }

    // -------------------------------------------------------
    // XÓA môn học
    // Kiểm tra ràng buộc: không cho xóa nếu đã có sinh viên đăng ký (bảng DKMH)
    // -------------------------------------------------------
    public static bool DelCourse(string mamh)
    {
        MY_DB db = new MY_DB();
        try
        {
            db.openConnection();

            // 1. Kiểm tra sinh viên đã đăng ký môn này chưa
            string checkQuery = "SELECT COUNT(*) FROM DKMH WHERE MaMH = @ma";
            SqlCommand checkCmd = new SqlCommand(checkQuery, db.conn);
            checkCmd.Parameters.AddWithValue("@ma", mamh);

            int count = (int)checkCmd.ExecuteScalar();
            if (count > 0)
                return false; // Có sinh viên đăng ký → không được xóa

            // 2. Xóa bình thường
            string deleteQuery = "DELETE FROM Course WHERE MaMH = @ma";
            SqlCommand cmd = new SqlCommand(deleteQuery, db.conn);
            cmd.Parameters.AddWithValue("@ma", mamh);

            return cmd.ExecuteNonQuery() > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }

    // -------------------------------------------------------
    // LẤY DANH SÁCH môn học (có tìm kiếm, lọc học kỳ, sắp xếp)
    // -------------------------------------------------------
    public static DataTable GetCourse(string search = "", string hockyFilter = "Tất cả", string sortBy = "")
    {
        MY_DB db = new MY_DB();
        DataTable dt = new DataTable();
        try
        {
            db.openConnection();
            string query = "SELECT MaMH, TenMH, SoTC, Tuan, Hky, Mota FROM Course WHERE 1=1";

            // Tìm kiếm theo mã hoặc tên môn học
            if (!string.IsNullOrEmpty(search))
                query += " AND (MaMH LIKE @search OR TenMH LIKE @search)";

            // Lọc theo học kỳ
            if (!string.IsNullOrEmpty(hockyFilter) && hockyFilter != "Tất cả")
                query += " AND Hky = @hocky";

            // Sắp xếp
            switch (sortBy)
            {
                case "Theo Mã MH":   query += " ORDER BY MaMH ASC";  break;
                case "Theo Tên A-Z": query += " ORDER BY TenMH ASC"; break;
                case "Theo Tên Z-A": query += " ORDER BY TenMH DESC"; break;
                case "Theo Số TC":   query += " ORDER BY SoTC DESC"; break;
                default:             query += " ORDER BY MaMH ASC";  break;
            }

            SqlCommand cmd = new SqlCommand(query, db.conn);
            if (!string.IsNullOrEmpty(search))
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
            if (!string.IsNullOrEmpty(hockyFilter) && hockyFilter != "Tất cả")
                cmd.Parameters.AddWithValue("@hocky", hockyFilter);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        finally { db.closeConnection(); }
    }
}
