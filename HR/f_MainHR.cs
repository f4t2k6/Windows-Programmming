using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using YourApp;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]

    public partial class f_MainHR : Form, IMessageFilter
    {
        private Form? activeForm = null;
        public f_MainHR()
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
            // 1. Nếu đang có một Form con khác mở, đóng hoàn toàn để giải phóng bộ nhớ
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            // 2. Gán Form con mới vào biến theo dõi
            activeForm = childForm;

            // 3. Thiết lập bộ 3 thuộc tính gác cổng quan trọng
            childForm.TopLevel = false;                      // Biến form thành control nội bộ
            childForm.FormBorderStyle = FormBorderStyle.None; // Xóa sạch khung viền và thanh tiêu đề
            childForm.Dock = DockStyle.Fill;                // Tự động kéo giãn khít theo kích thước Panel

            // 4. Dọn dẹp Panel và nạp Form con vào
            targetPanel.Controls.Clear();                    // Xóa sạch các điều khiển/giao diện cũ trong panel
            targetPanel.Controls.Add(childForm);            // Thêm form con vào panel
            targetPanel.Tag = childForm;                    // Lưu trữ tham chiếu nếu cần dùng sau này

            // 5. Hiển thị Form con lên màn hình
            childForm.BringToFront();                       // Đẩy lên lớp trên cùng để không bị che khuất
            childForm.Show();                               // Kích hoạt hiển thị
        }

        private void btn_Logout_MainHR_Click(object sender, EventArgs e)
        {
            // 1. Xóa toàn bộ dữ liệu phiên đăng nhập khỏi RAM
            Globals.ClearSession();

            // 2. Ẩn form hiện tại đi
            this.Hide();

            // 3. Khởi tạo lại và hiển thị form Đăng nhập
            f_Login formLogin = new f_Login();
            formLogin.ShowDialog();

            // 4. Giải phóng hoàn toàn form cũ sau khi form login đóng
            this.Close();
        }

        private void btn_ListStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListStudent(), pnl_content_MainHR);
        }

        private void btn_ListScore_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListScore(-1, ""), pnl_content_MainHR);
        }

        private void btn_ManageCourse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ManageCourse(), pnl_content_MainHR);
        }

        private void pnl_content_MainHR_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_MainHR_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pb_Logo_HR_Click(object sender, EventArgs e)
        {

        }

        private void button_Classroom_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmClassroom(), pnl_content_MainHR);
        }

        private void button_Chart_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe(), pnl_content_MainHR);
        }

        private void button_Assign_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_Assign("HR", Globals.GlobalUserId.ToString()), pnl_content_MainHR);
        }

        private void button_Contact_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_Contact(Globals.GlobalUserId), pnl_content_MainHR);
        }

        private void pictureBox_Quanlylophoc_Click(object sender, EventArgs e)
        {

        }

        // ============================================================
        // MỚI: Hiển thị ảnh đại diện (bo tròn) + thông tin người dùng từ bảng HR
        // ============================================================
        private void f_MainHR_Load(object sender, EventArgs e)
        {
            LoadUserProfile();

            // ── Session timeout: tự đăng xuất sau 2 phút không hoạt động ──
            Application.AddMessageFilter(this);  // bắt mọi event chuột/phím toàn app
            SessionManager.Instance.Start(this, DoLogout);
        }

        private void LoadUserProfile()
        {
            // Lấy thông tin từ RAM (Globals) — không query DB nữa
            // GlobalFullName đã được FetchFullName() lấy sẵn lúc đăng nhập
            string displayName = !string.IsNullOrEmpty(Globals.GlobalFullName)
                ? Globals.GlobalFullName
                : Globals.GlobalUsername;

            if (Globals.GlobalRole == "Admin")
            {
                // Admin: hiển thị tên + vai trò
                label_Info.Text = $"{displayName}\n💼 Quản trị viên\n📧 {Globals.GlobalEmail}";
                LoadAvatarImage(null);
                return;
            }

            // HR: hiển thị tên thật + ID + email
            label_Info.Text = $"{displayName}\n🆔 ID: {Globals.GlobalUserId}\n💼 {Globals.GlobalRole}\n📧 {Globals.GlobalEmail}";

            // Ảnh đại diện vẫn cần query vì ảnh (byte[]) chưa lưu vào Globals
            MY_DB my_db = new MY_DB();
            try
            {
                my_db.openConnection();
                string sql = "SELECT Pic FROM HR WHERE MSGV = @msgv";
                SqlCommand cmd = new SqlCommand(sql, my_db.conn);
                cmd.Parameters.Add("@msgv", SqlDbType.NVarChar, 20).Value = Globals.GlobalUserId.ToString();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[]? picBytes = reader["Pic"] != DBNull.Value
                            ? (byte[])reader["Pic"]
                            : null;
                        LoadAvatarImage(picBytes);
                    }
                    else
                    {
                        LoadAvatarImage(null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh đại diện: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadAvatarImage(null);
            }
            finally
            {
                my_db.closeConnection();
            }
        }

        // Nạp ảnh đại diện của người dùng đang đăng nhập (nếu có) và bo tròn
        private void LoadAvatarImage(byte[]? imageBytes)
        {
            Image baseImage;

            if (imageBytes != null && imageBytes.Length > 0)
            {
                // Có ảnh riêng của HR trong DB -> dùng ảnh đó
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

        // Bo tròn ảnh đại diện theo kích thước PictureBox
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

        private void label_Info_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_Avatar_Click(object sender, EventArgs e)
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
            return false; // không tiêu thụ message, cho app xử lý bình thường
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
            // Dọn dẹp: hủy đăng ký filter và dừng session manager
            Application.RemoveMessageFilter(this);
            SessionManager.Instance.Stop();
        }
    }
}