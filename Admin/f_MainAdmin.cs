using System;
using System.Windows.Forms;
using YourApp;
using ProjectMonHoc.Child_Forms;

namespace ProjectMonHoc
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_MainAdmin : Form
    {
        private Form? activeForm = null;

        public f_MainAdmin()
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
            Globals.GlobalUsername = string.Empty;
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
            OpenChildForm(new f_Assign(), panel_Content);
        }

        private void button_Contact_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_Contact(Globals.GlobalUserId), panel_Content);
        }

        private void button_createTB_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_createTB_DB(), panel_Content);
        }
    }
}