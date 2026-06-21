using Microsoft.Data.SqlClient;
using System.Data;

public class Registration
{
    // Đăng ký môn học
    public static bool RegisterCourse(int mssv, string mamh)
    {
        MY_DB db = new MY_DB();
        try
        {
            db.openConnection();
            string query = "INSERT INTO DKMH (MSSV, MaMH) VALUES (@mssv, @mamh)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            cmd.Parameters.AddWithValue("@mamh", mamh.Trim());
            return cmd.ExecuteNonQuery() > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }

    // Hủy đăng ký môn học
    public static bool UnregisterCourse(int mssv, string mamh)
    {
        MY_DB db = new MY_DB();
        try
        {
            db.openConnection();
            string query = "DELETE FROM DKMH WHERE MSSV = @mssv AND MaMH = @mamh";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            cmd.Parameters.AddWithValue("@mamh", mamh.Trim());
            return cmd.ExecuteNonQuery() > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }

    // Lấy danh sách môn đã đăng ký của một sinh viên
    public static DataTable GetRegisteredCourses(int mssv)
    {
        MY_DB db = new MY_DB();
        DataTable dt = new DataTable();
        try
        {
            db.openConnection();
            string query = @"
                SELECT c.MaMH, c.TenMH, c.SoTC, c.Hky
                FROM DKMH d
                INNER JOIN Course c ON d.MaMH = c.MaMH
                WHERE d.MSSV = @mssv
                ORDER BY c.Hky, c.TenMH";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        finally { db.closeConnection(); }
    }

    // Tính tổng tín chỉ sinh viên đã đăng ký trong 1 học kỳ
    public static int GetTotalCredits(int mssv, int hocky)
    {
        MY_DB db = new MY_DB();
        try
        {
            db.openConnection();
            string query = @"
            SELECT ISNULL(SUM(c.SoTC), 0)
            FROM DKMH d
            INNER JOIN Course c ON d.MaMH = c.MaMH
            WHERE d.MSSV = @mssv AND c.Hky = @hocky";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            cmd.Parameters.AddWithValue("@hocky", hocky);
            return (int)cmd.ExecuteScalar();
        }
        catch { return 0; }
        finally { db.closeConnection(); }
    }
}