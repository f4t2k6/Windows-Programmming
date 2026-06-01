using System;
using System.Windows.Forms;

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

        // Hàm gác cổng quản lý vòng đời và hiển thị form con duy nhất trong panel2
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

            // 3. Thiết lập thuộc tính để đưa form lồng vào panel như một Control
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // 4. Dọn dẹp Panel và nạp Form con vào
            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(childForm);
            targetPanel.Tag = childForm;

            // 5. Hiển thị Form con lên màn hình
            childForm.BringToFront();
            childForm.Show();
        }

        // =========================================================
        // ĐIỀU HƯỚNG CÁC CHỨC NĂNG SANG PANEL2
        // =========================================================

        private void btn_letter_MainAdmin_Click(object sender, EventArgs e)
        {

            OpenChildForm(new f_AdminRequests(), panel4);
        }

        private void btn_ListStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListStudent(), panel4);
        }

        private void btn_ManageCourse_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ManageCourse(), panel4);
        }

        private void btn_ListScore_Click(object sender, EventArgs e)
        {
            OpenChildForm(new f_ListScore(-1, ""), panel4);
        }

        private void btn_Logout_MainAdmin_Click(object sender, EventArgs e)
        {
            Globals.GlobalUsername = string.Empty;
            this.Hide();

            f_Login formLogin = new f_Login();
            formLogin.ShowDialog();

            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Chart_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe(), panel4);
        }
    }
}