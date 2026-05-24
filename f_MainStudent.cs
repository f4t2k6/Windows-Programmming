using System;
using System.Windows.Forms;

namespace ProjectMonHoc
{
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

        private void btn_Logout_MainStudent_Click(object sender, EventArgs e)
        {
            Globals.GlobalUsername = string.Empty;
            this.Hide();
            f_Login formLogin = new f_Login();
            formLogin.ShowDialog();
            this.Close();
        }

        private void btn_StudentScore_Click(object sender, EventArgs e)
        {
            // Lấy ID và Username của chính sinh viên đang đăng nhập để hiển thị điểm
            string studentName = Globals.GlobalUsername;
            int studentMSSV = Globals.GlobalUserId;

            // Mở form f_ListScore giống như HR, nhưng vì truyền MSSV của sinh viên nên form sẽ chỉ load điểm của sinh viên đó
            OpenChildForm(new f_ListScore(studentMSSV, studentName), pnl_content_MainStudent);
        }

        private void btn_StudentInfo_Click(object sender, EventArgs e)
        {
            // Tạm thời chưa xử lý
        }
    }
}