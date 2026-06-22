using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectMonHoc
{
    public partial class f_StudentInfo : Form
    {
        public f_StudentInfo()
        {
            InitializeComponent();
        }

        private void f_StudentInfo_Load(object sender, EventArgs e)
        {
            LoadStudentInfo();
            LoadScoreChart();
        }

        // =============================================
        // LOAD THÔNG TIN SINH VIÊN ĐANG ĐĂNG NHẬP
        // =============================================
        private void LoadStudentInfo()
        {
            int mssv = Globals.GlobalMSSV;
            if (mssv <= 0)
            {
                MessageBox.Show("Không xác định được sinh viên đang đăng nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MY_DB db = new MY_DB();
            try
            {
                db.openConnection();

                string query = @"
                    SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email,
                           Pture, PrintRequest, PrintRequestDate
                    FROM Student
                    WHERE MSSV = @mssv";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        string fname = GetSafeString(dr, "Fname");
                        string lname = GetSafeString(dr, "Lname");

                        // ----- Card avatar (trên-trái) -----
                        lblFullName.Text = $"{fname} {lname}".Trim();
                        lblMSSVHeader.Text = $"MSSV: {mssv}";

                        // ----- Thông tin cá nhân -----
                        lblMSSVVal.Text = mssv.ToString();

                        object dobObj = dr["Dob"];
                        lblDobVal.Text = (dobObj == DBNull.Value)
                            ? "---"
                            : Convert.ToDateTime(dobObj).ToString("dd/MM/yyyy");

                        lblGenderVal.Text = GetSafeString(dr, "Gder", "---");

                        // ----- Thông tin liên hệ -----
                        lblPhoneVal.Text = GetSafeString(dr, "Phone", "---");
                        lblEmailVal.Text = GetSafeString(dr, "Email", "---");
                        lblAddressVal.Text = GetSafeString(dr, "Address", "---");
                        lblHtownVal.Text = GetSafeString(dr, "Htown", "---");

                        // ----- Trạng thái yêu cầu in ấn -----
                        string printRequest = GetSafeString(dr, "PrintRequest", "");
                        lblPrintReqVal.Text = string.IsNullOrEmpty(printRequest)
                            ? "Chưa có yêu cầu"
                            : printRequest;

                        object printDateObj = dr["PrintRequestDate"];
                        lblPrintReqDateVal.Text = (printDateObj == DBNull.Value)
                            ? "---"
                            : Convert.ToDateTime(printDateObj).ToString("dd/MM/yyyy HH:mm");

                        // ----- Ảnh đại diện -----
                        object ptureObj = dr["Pture"];
                        if (ptureObj != DBNull.Value)
                        {
                            byte[] imgBytes = (byte[])ptureObj;
                            using (MemoryStream ms = new MemoryStream(imgBytes))
                            {
                                picAvatar.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin sinh viên.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin sinh viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        // =============================================
        // LOAD BIỂU ĐỒ CỘT ĐIỂM CÁC MÔN HỌC
        // =============================================
        private void LoadScoreChart()
        {
            int mssv = Globals.GlobalMSSV;
            if (mssv <= 0) return;

            try
            {
                DataTable dt = Score.GetScores(mssv);

                chartScores.Series["Điểm tổng kết"].Points.Clear();

                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    string courseId = row["course_id"]?.ToString() ?? "";
                    object diemTkObj = row["DiemTK"];
                    double diemTK = (diemTkObj == DBNull.Value) ? 0 : Convert.ToDouble(diemTkObj);

                    int idx = chartScores.Series["Điểm tổng kết"].Points.AddXY(courseId, diemTK);

                    DataPoint pt = chartScores.Series["Điểm tổng kết"].Points[idx];
                    pt.Color = GetColorByDiem(diemTK);
                    pt.Label = diemTK.ToString("0.00");
                    pt.ToolTip = $"{courseId}: {diemTK:0.00} điểm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu đồ điểm: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Color GetColorByDiem(double diemTK)
        {
            if (diemTK >= 8.0) return Color.FromArgb(46, 160, 67);   // Giỏi/Xuất sắc - xanh lá
            if (diemTK >= 6.5) return Color.FromArgb(22, 110, 191);  // Khá - xanh dương
            if (diemTK >= 5.0) return Color.FromArgb(255, 170, 60);  // Trung bình - cam
            return Color.FromArgb(214, 69, 65);                      // Yếu - đỏ
        }

        private static string GetSafeString(SqlDataReader dr, string column, string defaultValue = "")
        {
            object val = dr[column];
            return (val == DBNull.Value) ? defaultValue : val.ToString();
        }

        // =============================================
        // BO TRÒN AVATAR
        // =============================================
        private void picAvatar_Resize(object sender, EventArgs e)
        {
            SetCircleRegion(picAvatar);
        }

        private void picAvatar_Paint(object sender, PaintEventArgs e)
        {
            SetCircleRegion(picAvatar);
        }

        private static void SetCircleRegion(Control control)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, control.Width, control.Height);
            control.Region = new Region(path);
        }

        private void picAvatar_Click(object sender, EventArgs e)
        {

        }

        private void panelInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartScores_Click(object sender, EventArgs e)
        {

        }
    }
}