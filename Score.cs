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
        public double ScoreValue { get; set; }
        public string Description { get; set; }

        public Score(int studentId, string courseId, string courseName, double scoreValue, string description)
        {
            StudentId = studentId;
            CourseId = courseId;
            CourseName = courseName;
            ScoreValue = scoreValue;
            Description = description;
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
                string query = @"SELECT student_id, course_id, course_name, score, description
                                 FROM Score
                                 WHERE student_id = @StudentId";

                if (!string.IsNullOrEmpty(search))
                    query += " AND (course_id LIKE @search OR course_name LIKE @search OR description LIKE @search)";

                switch (sortBy)
                {
                    case "Theo Mã môn (A-Z)": query += " ORDER BY course_id ASC"; break;
                    case "Theo Điểm (Cao - Thấp)": query += " ORDER BY score DESC"; break;
                    case "Theo Điểm (Thấp - Cao)": query += " ORDER BY score ASC"; break;
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
        // CẬP NHẬT ĐIỂM (UPDATE)
        // =============================================
        public bool EditScore()
        {
            try
            {
                db.openConnection();
                string query = @"UPDATE Score
                                 SET course_name = @CourseName,
                                     score       = @Score,
                                     description = @Description
                                 WHERE student_id = @StudentId
                                   AND course_id  = @CourseId";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@CourseName", CourseName);
                cmd.Parameters.AddWithValue("@Score", ScoreValue);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(Description) ? (object)DBNull.Value : Description);
                cmd.Parameters.AddWithValue("@StudentId", StudentId);
                cmd.Parameters.AddWithValue("@CourseId", CourseId);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }
    }
}