using System;
using System.Windows.Forms;
using YourApp;
using ProjectMonHoc.Child_Forms;


namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_MainAdmin : Form, IMessageFilter
    {
        private Form? activeForm = null;

        public f_MainAdmin()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // ── Session timeout: tự đăng xuất sau 2 phút không hoạt động ──
            Application.AddMessageFilter(this);
            SessionManager.Instance.Start(this, DoLogout);
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

        // ── ĐIỀU HƯỚNG ────────────────────────────────────────────────

        /// <summary>
        /// Nút "📩 Hộp thư" — mở form duyệt yêu cầu in giấy xác nhận SV.
        /// (Cũng có thể mở f_AdminRequests nếu dự án còn dùng form đó cho HR requests)
        /// </summary>
        private void btn_letter_MainAdmin_Click(object sender, EventArgs e)
        {
            // MỚI: mở hộp thư yêu cầu in giấy SV
            OpenChildForm(new f_AdminRequests(), panel_Content);
        }

        private void btn_ListStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListStudent(), panel_Content);
        }

        private void btn_ManageCourse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ManageCourse(), panel_Content);
        }

        private void btn_ListScore_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListScore(-1, ""), panel_Content);
        }

        private void btn_Logout_MainAdmin_Click(object sender, EventArgs e)
        {
            // Xóa toàn bộ dữ liệu phiên đăng nhập khỏi RAM
            Globals.ClearSession();
            this.Hide();
            f_Login formLogin = new f_Login();
            formLogin.ShowDialog();
            this.Close();
        }

        private void button_Chart_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe(), panel_Content);
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel_Content_Paint(object sender, PaintEventArgs e) { }

        private void pnl_Sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_ListStudent_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListStudent(), panel_Content);
        }

        private void btn_ListScore_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListScore(-1, ""), panel_Content);
        }

        private void btn_ManageCourse_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new f_ManageCourse(), panel_Content);
        }

        private void button_Chart_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe(), panel_Content);
        }

        private void button_Classroom_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmClassroom(), panel_Content);
        }

        private void button_Assign_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_Assign("Admin", null), panel_Content);
        }

        private void button_Contact_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_Contact(Globals.GlobalUserId), panel_Content);
        }

        private void button_createTB_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_createTB_DB(), panel_Content);
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