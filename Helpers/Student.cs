using Microsoft.Data.SqlClient;
using System.Data;

public class Student
{
    MY_DB db = new MY_DB();

    public int MSSV { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public DateTime Dob { get; set; }
    public string Gender { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Hometown { get; set; }
    public string Email { get; set; }
    public byte[] Picture { get; set; }

    // Constructor
    public Student(int mssv, string fname, string lname, DateTime dob,
        string gender, string phone, string address, string hometown,
        string email, byte[] picture)
    {
        MSSV = mssv; Fname = fname; Lname = lname; Dob = dob;
        Gender = gender; Phone = phone; Address = address;
        Hometown = hometown; Email = email; Picture = picture;
    }
    public Student() { }

    public bool AddStudent()
    {
        try
        {
            db.openConnection();
            string query = "INSERT INTO Student VALUES " +
                "(@mssv, @fname, @lname, @dob, @gder, @phone, @addr, @htown, @email, @pic)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@mssv", MSSV);
            cmd.Parameters.AddWithValue("@fname", Fname);
            cmd.Parameters.AddWithValue("@lname", Lname);
            cmd.Parameters.AddWithValue("@dob", Dob);
            cmd.Parameters.AddWithValue("@gder", Gender);
            cmd.Parameters.AddWithValue("@phone", Phone);
            cmd.Parameters.AddWithValue("@addr", Address);
            cmd.Parameters.AddWithValue("@htown", Hometown);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@pic", (object)Picture ?? DBNull.Value);

            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }
    public static DataTable GetStudents(string search = "", string genderFilter = "Tất cả", string sortBy = "")
    {
        MY_DB db = new MY_DB();
        DataTable dt = new DataTable();
        try
        {
            db.openConnection();
            string query = "SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture FROM Student WHERE 1=1";

            if (!string.IsNullOrEmpty(search))
                query += " AND (CAST(MSSV AS NVARCHAR) LIKE @search OR Fname LIKE @search OR Lname LIKE @search)";

            if (!string.IsNullOrEmpty(genderFilter) && genderFilter != "Tất cả")
                query += " AND Gder = @gender";

            switch (sortBy)
            {
                case "Theo MSSV": query += " ORDER BY MSSV ASC"; break;
                case "Theo Tên (A-Z)": query += " ORDER BY Lname ASC, Fname ASC"; break;
                case "Theo Tên (Z-A)": query += " ORDER BY Lname DESC, Fname DESC"; break;
                default: query += " ORDER BY MSSV ASC"; break;
            }

            SqlCommand cmd = new SqlCommand(query, db.conn);
            if (!string.IsNullOrEmpty(search)) cmd.Parameters.AddWithValue("@search", "%" + search + "%");
            if (!string.IsNullOrEmpty(genderFilter) && genderFilter != "Tất cả") cmd.Parameters.AddWithValue("@gender", genderFilter);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        finally { db.closeConnection(); }
    }

    public bool EditStudent()
    {
        try
        {
            db.openConnection();
            // Cập nhật tất cả các thông tin dựa trên khóa chính MSSV
            string query = "UPDATE Student SET Fname = @fname, Lname = @lname, Dob = @dob, " +
                           "Gder = @gder, Phone = @phone, Address = @addr, Htown = @htown, " +
                           "Email = @email, Pture = @pic WHERE MSSV = @mssv";

            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@mssv", MSSV);
            cmd.Parameters.AddWithValue("@fname", Fname);
            cmd.Parameters.AddWithValue("@lname", Lname);
            cmd.Parameters.AddWithValue("@dob", Dob);
            cmd.Parameters.AddWithValue("@gder", Gender);
            cmd.Parameters.AddWithValue("@phone", Phone);
            cmd.Parameters.AddWithValue("@addr", Address);
            cmd.Parameters.AddWithValue("@htown", Hometown);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@pic", (object)Picture ?? DBNull.Value);

            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }

    public static bool DeleteStudent(int mssv)
    {
        MY_DB db = new MY_DB();
        try
        {
            db.openConnection();

            // 1. Kiểm tra xem sinh viên đã có điểm trong bảng Score chưa
            string checkScoreQuery = "SELECT COUNT(*) FROM Score WHERE student_id = @mssv";
            // Lưu ý: Bạn hãy kiểm tra lại tên cột (VD: student_id hoặc MSSV) và tên bảng điểm trong DB của bạn xem có đúng là 'Score' không nhé.

            SqlCommand checkCmd = new SqlCommand(checkScoreQuery, db.conn);
            checkCmd.Parameters.AddWithValue("@mssv", mssv);

            int scoreCount = (int)checkCmd.ExecuteScalar();
            if (scoreCount > 0)
            {
                // Trả về false hoặc bạn có thể tạo một Exception riêng, ở đây ta trả về false để Form xử lý báo lỗi ràng buộc
                return false;
            }

            // 2. Nếu chưa có điểm thì tiến hành xóa bình thường
            string deleteQuery = "DELETE FROM Student WHERE MSSV = @mssv";
            SqlCommand cmd = new SqlCommand(deleteQuery, db.conn);
            cmd.Parameters.AddWithValue("@mssv", mssv);

            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            db.closeConnection();
        }
    }

    public static DataTable GetStudentsForCombo()
    {
        MY_DB db = new MY_DB();
        DataTable dt = new DataTable();
        try
        {
            db.openConnection();
            string query = "SELECT MSSV, Lname + ' ' + Fname AS HoTen FROM Student ORDER BY Lname";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.conn);
            adapter.Fill(dt);
            return dt;
        }
        finally { db.closeConnection(); }
    }
}
