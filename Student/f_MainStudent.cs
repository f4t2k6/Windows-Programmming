using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_MainStudent : Form, IMessageFilter
    {
        private Form? activeForm = null;

        public f_MainStudent()
        {
            InitializeComponent();
            SetupFaceRegistrationMenu();
        }

        private void SetupFaceRegistrationMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item = new ToolStripMenuItem("Đăng ký khuôn mặt");
            item.Click += (s, e) => {
                var form = new ProjectMonHoc.Login.f_FaceRegistration();
                form.ShowDialog();
            };
            menu.Items.Add(item);
            pictureBox_Avatar.ContextMenuStrip = menu;
            
            // Show menu on left click as well
            pictureBox_Avatar.MouseClick += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    menu.Show(pictureBox_Avatar, e.Location);
                }
            };
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
            // Xóa toàn bộ dữ liệu phiên đăng nhập khỏi RAM
            Globals.ClearSession();
            this.Hide();
            f_Login formLogin = new f_Login();
            formLogin.ShowDialog();
            this.Close();
        }

        private void btn_Student_Score_Click(object sender, EventArgs e)
        {
            // Lấy fullName từ RAM — không cần query DB
            string fullName = !string.IsNullOrEmpty(Globals.GlobalFullName)
                ? Globals.GlobalFullName
                : Globals.GlobalUsername;
            OpenChildForm(new f_ListScore(Globals.GlobalMSSV, fullName), pnl_Content_Student);
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
            // Lấy fullName từ RAM — không cần query DB
            string fullName = !string.IsNullOrEmpty(Globals.GlobalFullName)
                ? Globals.GlobalFullName
                : Globals.GlobalUsername;

            // Mở form f_PrintRequest trong panel nội dung
            OpenChildForm(new f_PrintRequest(Globals.GlobalMSSV, fullName), pnl_Content_Student);
        }

        // ============================================================
        // MỚI: Mở Chatbot AI Điều hướng
        // ============================================================
        private void btn_AskAINavi_Click(object sender, EventArgs e)
        {
            string fullName = !string.IsNullOrEmpty(Globals.GlobalFullName)
                ? Globals.GlobalFullName
                : Globals.GlobalUsername;

            f_NavigationChatbot chatbot = new f_NavigationChatbot(fullName);
            
            // Xử lý callback khi AI trả về Intent
            chatbot.onNavigate = (intent) =>
            {
                // Thực thi điều hướng trên luồng giao diện chính (UI Thread)
                this.Invoke((MethodInvoker)delegate
                {
                    switch (intent.ToUpper())
                    {
                        case "SCORE":
                            btn_Student_Score_Click(null, EventArgs.Empty);
                            break;
                        case "INFO":
                            btn_Student_Info_Click(null, EventArgs.Empty);
                            break;
                        case "TIMETABLE":
                            btn_Timetable_Click(null, EventArgs.Empty);
                            break;
                        case "COURSE_REGISTER":
                            btn_RegisterCourse_Click(null, EventArgs.Empty);
                            break;
                        case "PRINT_REQUEST":
                            btn_PrintRequest_Click(null, EventArgs.Empty);
                            break;
                        default:
                            break;
                    }
                });
            };

            chatbot.Show(this); // Hiển thị dưới dạng Tool Window không khóa Form chính
        }

        // ── sự kiện giao diện không cần logic ──────────────────────
        private void pnl_Side_Student_Paint(object sender, PaintEventArgs e) { }
        private void pb_main_student_Click(object sender, EventArgs e) { }
        private void f_MainStudent_Load(object sender, EventArgs e)
        {
            LoadUserProfile();

            // ── Session timeout: tự đăng xuất sau 2 phút không hoạt động ──
            Application.AddMessageFilter(this);
            SessionManager.Instance.Start(this, DoLogout);
        }

        // ============================================================
        // MỚI: Hiển thị ảnh đại diện (bo tròn) + thông tin người dùng
        // ============================================================
        private void LoadUserProfile()
        {
            // Lấy thông tin từ RAM (Globals) — không query DB nữa
            string displayName = !string.IsNullOrEmpty(Globals.GlobalFullName)
                ? Globals.GlobalFullName
                : Globals.GlobalUsername;

            // Hiển thị thông tin đầy đủ: Tên | MSSV | Chức vụ | Email
            label_Info.Text = $"{displayName}\n🆔 MSSV: {Globals.GlobalMSSV}\n💼 {Globals.GlobalRole}\n📧 {Globals.GlobalEmail}";

            // Ảnh đại diện vẫn cần query vì ảnh (byte[]) chưa lưu vào Globals
            DataTable dt = Student.GetStudents(Globals.GlobalMSSV.ToString(), "Tất cả", "Theo MSSV");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                byte[]? picBytes = null;
                if (dt.Columns.Contains("Pture") && row["Pture"] != DBNull.Value)
                    picBytes = (byte[])row["Pture"];
                LoadAvatarImage(picBytes);
            }
            else
            {
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // ============================================================
        // SESSION TIMEOUT — IMessageFilter + Auto-Logout
        // ============================================================

        /// <summary>
        /// Interceptor toàn ứng dụng: reset bộ đếm idle khi phát hiện
        /// chuột di chuyển, click, cuộn trang hoặc nhấn phím.
        /// </summary>
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_KEYDOWN     = 0x0100;
            const int WM_MOUSEMOVE   = 0x0200;
            const int WM_LBUTTONDOWN = 0x0201;
            const int WM_RBUTTONDOWN = 0x0204;
            const int WM_MOUSEWHEEL  = 0x020A;

            if (m.Msg == WM_KEYDOWN     ||
                m.Msg == WM_MOUSEMOVE   ||
                m.Msg == WM_LBUTTONDOWN ||
                m.Msg == WM_RBUTTONDOWN ||
                m.Msg == WM_MOUSEWHEEL)
            {
                SessionManager.Instance.ResetActivity();
            }
            return false;
        }

        /// <summary>
        /// Callback đăng xuất do SessionManager gọi trên UI thread khi hết timeout.
        /// </summary>
        private void DoLogout()
        {
            if (this.IsDisposed) return;
            Globals.ClearSession();
            this.Hide();
            f_Login formLogin = new f_Login();
            formLogin.ShowDialog();
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.RemoveMessageFilter(this);
            SessionManager.Instance.Stop();
        }
    }
}