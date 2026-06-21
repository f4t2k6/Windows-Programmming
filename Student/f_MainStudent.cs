using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_MainStudent : Form
    {
        private Form? activeForm = null;

        public f_MainStudent()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm, Panel targetPanel)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(childForm);
            targetPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_Logout_Student_Click(object sender, EventArgs e)
        {
            Globals.GlobalUsername = string.Empty;
            this.Hide();
            f_Login formLogin = new f_Login();
            formLogin.ShowDialog();
            this.Close();
        }

        private void btn_Student_Score_Click(object sender, EventArgs e)
        {
            DataTable dt = Student.GetStudents(Globals.GlobalMSSV.ToString(), "Tất cả", "Theo MSSV");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRow row = dt.Rows[0];
            int mssv = Convert.ToInt32(row["MSSV"]);
            string fullName = $"{row["Fname"]} {row["Lname"]}".Trim();
            OpenChildForm(new f_ListScore(mssv, fullName), pnl_Content_Student);
        }

        private void btn_Student_Info_Click(object sender, EventArgs e)
        {
            // TODO: mở form thông tin cá nhân
            OpenChildForm(new f_StudentInfo(), pnl_Content_Student);
        }

        private void btn_Timetable_Click(object sender, EventArgs e)
        {
            // TODO: mở form thời khóa biểu
        }

        private void btn_RegisterCourse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_RegisterCourse(), pnl_Content_Student);
        }

        // ============================================================
        // MỚI: Nút "In giấy Xác nhận Sinh viên"
        // ============================================================
        private void btn_PrintRequest_Click(object sender, EventArgs e)
        {
            // Lấy thông tin sinh viên từ MSSV đang đăng nhập
            DataTable dt = Student.GetStudents(Globals.GlobalMSSV.ToString(), "Tất cả", "Theo MSSV");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow row = dt.Rows[0];
            int mssv = Convert.ToInt32(row["MSSV"]);
            string fullName = $"{row["Fname"]} {row["Lname"]}".Trim();

            // Mở form f_PrintRequest trong panel nội dung
            OpenChildForm(new f_PrintRequest(mssv, fullName), pnl_Content_Student);
        }

        // ── sự kiện giao diện không cần logic ──────────────────────
        private void pnl_Side_Student_Paint(object sender, PaintEventArgs e) { }
        private void pb_main_student_Click(object sender, EventArgs e) { }
        private void f_MainStudent_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
        }

        // ============================================================
        // MỚI: Hiển thị ảnh đại diện (bo tròn) + thông tin người dùng
        // ============================================================
        private void LoadUserProfile()
        {
            // ── Admin: chỉ hiện chữ "Admin", dùng ảnh mặc định ──────
            if (Globals.GlobalRole == "Admin")
            {
                label_Info.Text = "Admin";
                LoadAvatarImage(null);
                return;
            }

            // ── Student / HR: lấy họ tên + ảnh đại diện theo MSSV đang đăng nhập ──
            DataTable dt = Student.GetStudents(Globals.GlobalMSSV.ToString(), "Tất cả", "Theo MSSV");

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                string fullName = $"{row["Fname"]} {row["Lname"]}".Trim();
                label_Info.Text = $"{fullName}\nID: {Globals.GlobalMSSV}";

                // Bảng Student lưu ảnh đại diện ở cột "Pture" (kiểu IMAGE)
                byte[]? picBytes = null;
                if (dt.Columns.Contains("Pture") && row["Pture"] != DBNull.Value)
                {
                    picBytes = (byte[])row["Pture"];
                }

                LoadAvatarImage(picBytes);
            }
            else
            {
                // Không lấy được thông tin chi tiết -> hiển thị tạm username + ID
                label_Info.Text = $"{Globals.GlobalUsername}\nID: {Globals.GlobalMSSV}";
                LoadAvatarImage(null);
            }
        }

        // ============================================================
        // Nạp ảnh đại diện của người dùng đang đăng nhập (nếu có) và bo tròn
        // ============================================================
        private void LoadAvatarImage(byte[]? imageBytes)
        {
            Image baseImage;

            if (imageBytes != null && imageBytes.Length > 0)
            {
                // Có ảnh riêng của người dùng trong DB -> dùng ảnh đó
                using (MemoryStream ms = new MemoryStream(imageBytes))
                using (Image temp = Image.FromStream(ms))
                {
                    baseImage = new Bitmap(temp); // copy ra để stream có thể đóng an toàn
                }
            }
            else
            {
                // Không có ảnh riêng -> dùng ảnh mặc định đang gán sẵn trong Designer
                baseImage = pictureBox_Avatar.Image ?? Properties.Resources.icons8_user_100;
            }

            pictureBox_Avatar.Image = GetRoundedImage(
                baseImage,
                pictureBox_Avatar.Width,
                pictureBox_Avatar.Height);
        }

        // Bo tròn ảnh đại diện theo kích thước PictureBox (hình tròn/oval)
        private Image GetRoundedImage(Image sourceImage, int width, int height)
        {
            Bitmap rounded = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(rounded))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, width, height);
                    g.SetClip(path);
                    g.DrawImage(sourceImage, 0, 0, width, height);
                }
            }
            return rounded;
        }
        private void pnl_content_Student_Paint(object sender, PaintEventArgs e) { }
    }
}