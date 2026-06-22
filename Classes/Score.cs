using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ProjectMonHoc
{
    public class Score
    {
        MY_DB db = new MY_DB();

        public int StudentId { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public double DiemQT { get; set; }   // Điểm quá trình (40%)
        public double DiemCK { get; set; }   // Điểm cuối kỳ  (60%)
        public double DiemTK { get; set; }   // Tự tính: QT*0.4 + CK*0.6
        public string Description { get; set; }

        // Tính DiemTK và phân loại
        public void CalculateDiemTK()
        {
            DiemTK = Math.Round(DiemQT * 0.4 + DiemCK * 0.6, 2);
        }

        public static string GetXepLoai(double diemTK)
        {
            if (diemTK >= 9.0) return "Xuất sắc";
            if (diemTK >= 8.0) return "Giỏi";
            if (diemTK >= 6.5) return "Khá";
            if (diemTK >= 5.0) return "Trung bình";
            return "Yếu";
        }

        // =============================================
        // LẤY DANH SÁCH ĐIỂM CỦA MỘT SINH VIÊN
        // =============================================
        public static DataTable GetScores(int studentMSSV, string search = "", string sortBy = "Mặc định")
        {
            MY_DB db = new MY_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = @"
                    SELECT student_id, course_id, course_name,
                           DiemQT, DiemCK, DiemTK,
                           CASE
                               WHEN DiemTK >= 9.0 THEN N'Xuất sắc'
                               WHEN DiemTK >= 8.0 THEN N'Giỏi'
                               WHEN DiemTK >= 6.5 THEN N'Khá'
                               WHEN DiemTK >= 5.0 THEN N'Trung bình'
                               WHEN DiemTK IS NOT NULL THEN N'Yếu'
                               ELSE N'Chưa có điểm'
                           END AS XepLoai,
                           description
                    FROM Score
                    WHERE student_id = @StudentId";

                if (!string.IsNullOrEmpty(search))
                    query += " AND (course_id LIKE @search OR course_name LIKE @search OR description LIKE @search)";

                switch (sortBy)
                {
                    case "Theo Mã môn (A-Z)": query += " ORDER BY course_id ASC"; break;
                    case "Theo Điểm (Cao - Thấp)": query += " ORDER BY DiemTK DESC"; break;
                    case "Theo Điểm (Thấp - Cao)": query += " ORDER BY DiemTK ASC"; break;
                    default: query += " ORDER BY course_id ASC"; break;
                }

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@StudentId", studentMSSV);
                if (!string.IsNullOrEmpty(search))
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
            catch { return dt; }
            finally { db.closeConnection(); }
        }

        // =============================================
        // TÍNH GPA (có trọng số tín chỉ)
        // =============================================
        public static (double gpa, int totalTC) GetGPA(int studentMSSV)
        {
            MY_DB db = new MY_DB();
            try
            {
                db.openConnection();
                // JOIN với Course để lấy SoTC
                string query = @"
                    SELECT ISNULL(SUM(s.DiemTK * c.SoTC), 0) AS TongDiemTC,
                           ISNULL(SUM(c.SoTC), 0)            AS TongTC
                    FROM Score s
                    INNER JOIN Course c ON s.course_id = c.MaMH
                    WHERE s.student_id = @mssv
                      AND s.DiemTK IS NOT NULL";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", studentMSSV);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    double tongDiemTC = Convert.ToDouble(dr["TongDiemTC"]);
                    int tongTC = Convert.ToInt32(dr["TongTC"]);
                    double gpa = tongTC > 0 ? Math.Round(tongDiemTC / tongTC, 2) : 0;
                    return (gpa, tongTC);
                }
                return (0, 0);
            }
            catch { return (0, 0); }
            finally { db.closeConnection(); }
        }

        // =============================================
        // THÊM ĐIỂM (INSERT)
        // =============================================
        public bool AddScore()
        {
            CalculateDiemTK();
            try
            {
                db.openConnection();
                string query = @"
                    INSERT INTO Score (student_id, course_id, course_name, DiemQT, DiemCK, DiemTK, description)
                    VALUES (@sid, @cid, @cname, @qt, @ck, @tk, @desc)";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@sid", StudentId);
                cmd.Parameters.AddWithValue("@cid", CourseId);
                cmd.Parameters.AddWithValue("@cname", CourseName);
                cmd.Parameters.AddWithValue("@qt", DiemQT);
                cmd.Parameters.AddWithValue("@ck", DiemCK);
                cmd.Parameters.AddWithValue("@tk", DiemTK);
                cmd.Parameters.AddWithValue("@desc", string.IsNullOrEmpty(Description) ? (object)DBNull.Value : Description);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        // =============================================
        // CẬP NHẬT ĐIỂM (UPDATE)
        // =============================================
        public bool EditScore()
        {
            CalculateDiemTK();
            try
            {
                db.openConnection();
                string query = @"
                    UPDATE Score
                    SET course_name = @CourseName,
                        DiemQT      = @qt,
                        DiemCK      = @ck,
                        DiemTK      = @tk,
                        description = @Description
                    WHERE student_id = @StudentId
                      AND course_id  = @CourseId";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@CourseName", CourseName);
                cmd.Parameters.AddWithValue("@qt", DiemQT);
                cmd.Parameters.AddWithValue("@ck", DiemCK);
                cmd.Parameters.AddWithValue("@tk", DiemTK);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? (object)DBNull.Value : Description);
                cmd.Parameters.AddWithValue("@StudentId", StudentId);
                cmd.Parameters.AddWithValue("@CourseId", CourseId);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }
    }
}