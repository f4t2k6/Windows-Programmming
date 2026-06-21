using Microsoft.Data.SqlClient;
using ProjectMonHoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    public partial class f_Login : Form
    {
        private int position;
        private Form? activeChildForm = null;
        public Panel LoginPanel
        {
            get { return panel_Login; }
        }



        public f_Login()
        {
            InitializeComponent();
        }

        private void f_Login_Load(object sender, EventArgs e)
        {
            // Mặc định mật khẩu đang ẩn -> icon hiển thị "eye_open" (gợi ý bấm để xem)
            ptb_ShowPass.Image = Properties.Resources.eye_open;

            if (Properties.Settings.Default.RememberLogin
                && !string.IsNullOrEmpty(Properties.Settings.Default.SavedUsername))
            {
                textBox_Taikhoan.Text = Properties.Settings.Default.SavedUsername;
                textBox_Matkhau.Text = Properties.Settings.Default.SavedPassword;
                checkBox_Ghinhodangnhap.Checked = true;
                radioButton_HR.Checked = (Properties.Settings.Default.SavedRole == "HR");
            }
            else
            {
                checkBox_Ghinhodangnhap.Checked = false;
            }
        }

        private void picturebox_Background_Click(object sender, EventArgs e)
        {

        }

        private void label_Matkhau_Click(object sender, EventArgs e)
        {

        }

        // Bật/tắt hiển thị mật khẩu (giống chức năng "con mắt" ở f_Register)
        private void ptb_ShowPass_Click(object sender, EventArgs e)
        {
            if (textBox_Matkhau.PasswordChar == '●')
            {
                textBox_Matkhau.PasswordChar = '\0';
                ptb_ShowPass.Image = Properties.Resources.eye_close;
            }
            else
            {
                textBox_Matkhau.PasswordChar = '●';
                ptb_ShowPass.Image = Properties.Resources.eye_open;
            }
        }


        private void button_Dangnhap_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            position = radioButton_HR.Checked ? 2 : 1;
            string roleStr = (position == 2) ? "HR" : "Student";
            string username = textBox_Taikhoan.Text.Trim();
            string inputPasswordHash = ComputeSHA256(textBox_Matkhau.Text); // Băm mật khẩu nhập vào

            MY_DB my_db = new MY_DB();

            try
            {
                my_db.openConnection();

                // Bước 1: Lấy thông tin tài khoản và kiểm tra xem có bị khóa không
                string selectQuery = "SELECT Id, username, password, role, email, ISNULL(LoginAttempts, 0) AS LoginAttempts " +
                                     "FROM login WHERE username COLLATE SQL_Latin1_General_CP1_CS_AS = @User AND role = @Role";

                SqlCommand command = new SqlCommand(selectQuery, my_db.conn);
                command.Parameters.Add("@User", SqlDbType.NChar).Value = username;
                command.Parameters.Add("@Role", SqlDbType.VarChar).Value = roleStr;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    int currentAttempts = Convert.ToInt32(row["LoginAttempts"]);
                    int userId = Convert.ToInt32(row["Id"]);
                    string dbPasswordHash = row["password"].ToString()?.Trim() ?? "";

                    // Kiểm tra trạng thái khóa tài khoản
                    if (currentAttempts >= 3)
                    {
                        MessageBox.Show("Tài khoản của bạn đã bị KHÓA do nhập sai quá 3 lần! Vui lòng liên hệ Admin để mở khóa.",
                            "Tài Khoản Bị Khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Bước 2: Kiểm tra mật khẩu (So sánh 2 chuỗi Hash SHA-256)
                    if (dbPasswordHash.Equals(inputPasswordHash, StringComparison.OrdinalIgnoreCase))
                    {
                        // Đăng nhập ĐÚNG -> Reset số lần sai về 0
                        string resetQuery = "UPDATE login SET LoginAttempts = 0 WHERE Id = @Id";
                        SqlCommand resetCmd = new SqlCommand(resetQuery, my_db.conn);
                        resetCmd.Parameters.AddWithValue("@Id", userId);
                        resetCmd.ExecuteNonQuery();

                        // Thiết lập Session toàn cục
                        Globals.SetSession(
                            id: userId,
                            username: row["username"].ToString() ?? "",
                            role: row["role"].ToString() ?? "",
                            email: row["email"].ToString() ?? ""
                        );

                        // Bước 3: Xử lý chức năng Remember Me
                        if (checkBox_Ghinhodangnhap.Checked)
                        {
                            Properties.Settings.Default.RememberLogin = true;
                            Properties.Settings.Default.SavedUsername = username;
                            Properties.Settings.Default.SavedPassword = textBox_Matkhau.Text;   // khi checked
                            Properties.Settings.Default.SavedRole = roleStr;                    // lưu role đã chọn (Student/HR)
                        }
                        else
                        {
                            Properties.Settings.Default.RememberLogin = false;
                            Properties.Settings.Default.SavedUsername = string.Empty;
                            Properties.Settings.Default.SavedPassword = string.Empty;    // khi unchecked
                            Properties.Settings.Default.SavedRole = string.Empty;
                        }
                        Properties.Settings.Default.Save(); // Lưu lại thay đổi vào file cấu hình

                        // =========================================================
                        // BƯỚC 4: LOGIC ĐIỀU HƯỚNG THEO ROLE
                        // =========================================================
                        this.Hide(); // Ẩn form đăng nhập

                        if (roleStr == "Student")
                        {
                            MessageBox.Show("Đăng nhập thành công với quyền Sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            f_MainStudent formStudent = new f_MainStudent();
                            formStudent.ShowDialog();
                        }
                        else if (roleStr == "HR")
                        {
                            // Kiểm tra tài khoản Admin mặc định (mật khẩu gốc nhập vào là 12345)
                            if (username == "Admin" && textBox_Matkhau.Text == "12345")
                            {
                                MessageBox.Show("Chào mừng Quản trị viên (Admin) hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                f_MainAdmin formAdmin = new f_MainAdmin();
                                formAdmin.ShowDialog();
                            }
                            else
                            {
                                // Tài khoản HR thường (Để trống chờ làm Form riêng)
                                MessageBox.Show("Chào mừng HR!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                f_MainHR formHR = new f_MainHR();
                                formHR.ShowDialog();
                            }
                        }

                        // Sau khi đóng Form chính (hoặc Form HR/Student), hiển thị lại Form Login
                        // để người dùng có thể đăng nhập tài khoản khác (Tương đương tính năng Đăng xuất)
                        this.Show();
                    }
                    else
                    {
                        string updateQuery = "UPDATE login SET LoginAttempts = LoginAttempts + 1 WHERE Id = @Id";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, my_db.conn);
                        updateCmd.Parameters.AddWithValue("@Id", userId);
                        updateCmd.ExecuteNonQuery();

                        int remainingAttempts = 3 - (currentAttempts + 1);

                        if (remainingAttempts <= 0)
                        {
                            MessageBox.Show("Tài khoản của bạn đã bị KHÓA do nhập sai 3 lần liên tiếp!",
                                "Thông Báo Khóa Tài Khoản", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            errorProvider_Baoloi.SetError(textBox_Matkhau, $"Sai mật khẩu! Bạn còn {remainingAttempts} lần thử.");
                            MessageBox.Show($"Sai tên đăng nhập hoặc mật khẩu! Bạn còn {remainingAttempts} lần thử đăng nhập hợp lệ.",
                                "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Trường hợp không tìm thấy trong bảng login
                    // Kiểm tra thêm: nếu là HR thì có thể tài khoản đang chờ duyệt trong register_HR
                    if (roleStr == "HR")
                    {
                        string pendingQuery = "SELECT COUNT(*) FROM register_HR WHERE Username = @User";
                        SqlCommand pendingCmd = new SqlCommand(pendingQuery, my_db.conn);
                        pendingCmd.Parameters.Add("@User", SqlDbType.VarChar).Value = username;
                        int pendingCount = (int)pendingCmd.ExecuteScalar();

                        if (pendingCount > 0)
                        {
                            // Tài khoản HR tồn tại nhưng chưa được Admin phê duyệt
                            MessageBox.Show("Tài khoản của bạn chưa được duyệt!\nVui lòng chờ Admin xét duyệt trước khi đăng nhập.",
                                "Tài Khoản Chờ Duyệt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Không tìm thấy ở bất kỳ đâu -> sai thông tin
                    errorProvider_Baoloi.SetError(textBox_Matkhau, "Sai tên đăng nhập hoặc mật khẩu!");
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý cơ sở dữ liệu: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
            }
        }

        private void panel_Login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_Dangnhap_Click(object sender, EventArgs e)
        {

        }

        private void radioButton_Sinhvien_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_HR_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label_Tendangnhap_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Taikhoan_TextChanged(object sender, EventArgs e)
        {
            errorProvider_Baoloi.SetError(textBox_Taikhoan,
            textBox_Taikhoan.Text.Trim() == "" ? "Vui lòng nhập tài khoản!" : "");
        }

        private void textBox_Matkhau_TextChanged(object sender, EventArgs e)
        {
            errorProvider_Baoloi.SetError(textBox_Matkhau,
            textBox_Matkhau.Text == "" ? "Vui lòng nhập mật khẩu!" : "");
        }

        private void checkBox_Ghinhodangnhap_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_Ghinhodangnhap.Checked)
            {
                Properties.Settings.Default.RememberLogin = false;
                Properties.Settings.Default.SavedUsername = string.Empty;
                Properties.Settings.Default.SavedPassword = string.Empty;
                Properties.Settings.Default.SavedRole = string.Empty;
                Properties.Settings.Default.Save();
            }
        }

        private void llbl_Dangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentRolePosition = radioButton_HR.Checked ? 2 : 1;
            f_Register registerForm = new f_Register(currentRolePosition, this);

            registerForm.onDone = () => RestoreLoginPanel();

            OpenChildForm(registerForm, panel_Login);
        }

        private void llbl_QuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentRole = radioButton_HR.Checked ? 2 : 1;

            f_ForgetPass forgetPassForm = new f_ForgetPass(currentRole, this);
            forgetPassForm.onBackToLogin = () => RestoreLoginPanel();

            OpenChildForm(forgetPassForm, panel_Login);
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        //==============================
        // CÁC HÀM HỖ TRỢ
        //==============================

        // Băm mật khẩu SHA-256
        private string ComputeSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Kiểm tra input trắng của Tài khoản và Mật khẩu
        private bool ValidateInputs()
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(textBox_Taikhoan.Text))
            {
                errorProvider_Baoloi.SetError(textBox_Taikhoan, "Vui lòng nhập tài khoản!");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox_Matkhau.Text))
            {
                errorProvider_Baoloi.SetError(textBox_Matkhau, "Vui lòng nhập mật khẩu!");
                valid = false;
            }

            return valid;
        }

        // Mở form con trong panel_Login
        internal void OpenChildForm(Form childForm, Panel targetPanel)
        {
            // Chỉ đóng form cũ nếu nó KHÁC với form mới đang được mở
            if (activeChildForm != null && activeChildForm != childForm)
            {
                Form old = activeChildForm;
                activeChildForm = null;
                old.Close();
            }

            activeChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            foreach (Control ctrl in targetPanel.Controls)
            {
                if (ctrl != childForm)
                    ctrl.Visible = false;
            }

            targetPanel.Controls.Add(childForm);
            targetPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Khôi phục panel_Login về trạng thái gốc
        internal void RestoreLoginPanel()
        {
            if (activeChildForm != null)
            {
                var old = activeChildForm;
                activeChildForm = null;
                if (!old.IsDisposed)
                    old.Close();
            }

            var toRemove = panel_Login.Controls
                .OfType<Form>()
                .ToList();
            foreach (var f in toRemove)
                panel_Login.Controls.Remove(f);

            foreach (Control ctrl in panel_Login.Controls)
                ctrl.Visible = true;
        }


    }
}