using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_ResetPass : Form
    {
        private string userEmail;
        private string userRole;
        private f_Login loginForm;
        public Action? onDone { get; set; }

        // Constructor nhận Email, Role VÀ loginForm từ luồng trước chuyển tới
        public f_ResetPass(string email, string role, f_Login loginForm)
        {
            InitializeComponent();
            this.userEmail = email;
            this.userRole = role;
            this.loginForm = loginForm;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string newPass = txb_NewPass.Text;
            string confirmPass = txb_ConfirmPass.Text;

            // Kiểm tra rỗng và khớp mật khẩu
            if (string.IsNullOrWhiteSpace(newPass) || newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới không được để trống và phải khớp với ô xác nhận!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra độ mạnh mật khẩu y hệt như form Register
            if (!IsStrongPassword(newPass))
            {
                MessageBox.Show("Mật khẩu quá yếu! Yêu cầu tối thiểu 8 ký tự, gồm chữ hoa, chữ thường, số và ký tự đặc biệt.", "Bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MY_DB my_db = new MY_DB();
            try
            {
                // Băm mật khẩu mới
                string hashedNewPass = ComputeSHA256(newPass);

                // Ghi đè vào bảng login. Đồng thời mở khóa tài khoản (LoginAttempts = 0) nếu đang bị khóa
                string query = "UPDATE login SET password = @pass, LoginAttempts = 0 WHERE email = @email AND role = @role";
                SqlCommand cmd = new SqlCommand(query, my_db.conn);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = hashedNewPass;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = userEmail;
                cmd.Parameters.Add("@role", SqlDbType.VarChar).Value = userRole;

                my_db.openConnection();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công! Bạn có thể dùng mật khẩu mới để đăng nhập.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    onDone?.Invoke(); // ← Quay về panel login sau khi cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, không thể cập nhật mật khẩu lúc này.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message);
            }
            finally
            {
                my_db.closeConnection();
            }
        }

        // Hàm băm SHA-256
        private string ComputeSHA256(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Hàm kiểm tra Regex mật khẩu mạnh
        private bool IsStrongPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        private void f_ResetPass_Load(object sender, EventArgs e)
        {
            // Mặc định cả 2 ô mật khẩu đang ẩn -> icon hiển thị "eye_open" (gợi ý bấm để xem) — giống y f_Register
            ptb_ShowNewPass.Image = Properties.Resources.eye_open;
            ptb_ShowConfirmPass.Image = Properties.Resources.eye_open;
        }

        private void lbl_ResetPass_Click(object sender, EventArgs e)
        {

        }

        private void txb_NewPass_TextChanged(object sender, EventArgs e)
        {
            UpdatePassMatchStatus();
        }

        // Sự kiện TextChanged cho ô Nhập lại mật khẩu (Xác nhận realtime) — giống y f_Register
        private void txb_ConfirmPass_TextChanged(object sender, EventArgs e)
        {
            UpdatePassMatchStatus();
        }

        // Cập nhật dấu tích xanh (khớp) hoặc dấu X đỏ (chưa khớp) kế bên ô Nhập lại mật khẩu
        private void UpdatePassMatchStatus()
        {
            if (string.IsNullOrEmpty(txb_ConfirmPass.Text))
            {
                lbl_PassStatus.Visible = false;
                return;
            }

            lbl_PassStatus.Visible = true;
            if (txb_ConfirmPass.Text == txb_NewPass.Text)
            {
                lbl_PassStatus.Text = "✓";
                lbl_PassStatus.ForeColor = Color.SeaGreen;
            }
            else
            {
                lbl_PassStatus.Text = "✗";
                lbl_PassStatus.ForeColor = Color.IndianRed;
            }
        }

        // Bật/tắt hiển thị mật khẩu mới (con mắt) — giống y f_Register
        private void ptb_ShowNewPass_Click(object sender, EventArgs e)
        {
            if (txb_NewPass.PasswordChar == '●')
            {
                txb_NewPass.PasswordChar = '\0';
                ptb_ShowNewPass.Image = Properties.Resources.eye_close;
            }
            else
            {
                txb_NewPass.PasswordChar = '●';
                ptb_ShowNewPass.Image = Properties.Resources.eye_open;
            }
        }

        // Bật/tắt hiển thị ô nhập lại mật khẩu (con mắt) — giống y f_Register
        private void ptb_ShowConfirmPass_Click(object sender, EventArgs e)
        {
            if (txb_ConfirmPass.PasswordChar == '●')
            {
                txb_ConfirmPass.PasswordChar = '\0';
                ptb_ShowConfirmPass.Image = Properties.Resources.eye_close;
            }
            else
            {
                txb_ConfirmPass.PasswordChar = '●';
                ptb_ShowConfirmPass.Image = Properties.Resources.eye_open;
            }
        }

        private void lbl_NewPass_Reset_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ConfirmPass_Reset_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_ResetPass_Click(object sender, EventArgs e)
        {
            onDone?.Invoke();
        }
    }
}