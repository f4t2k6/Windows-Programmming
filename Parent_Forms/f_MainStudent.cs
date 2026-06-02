using System;
using System.Data;
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
        private void f_MainStudent_Load(object sender, EventArgs e) { }
        private void pnl_content_Student_Paint(object sender, PaintEventArgs e) { }
    }
}