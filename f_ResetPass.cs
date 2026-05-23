using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProjectMonHoc
{
    public partial class f_ResetPass : Form
    {
        private string userEmail;
        private string userRole;

        // Constructor nhận Email và Role từ luồng trước chuyển tới
        public f_ResetPass(string email, string role)
        {
            InitializeComponent();
            this.userEmail = email;
            this.userRole = role;
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

            // (Tùy chọn) Kiểm tra độ mạnh mật khẩu y hệt như form Register
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
                    this.Close(); // Đóng form Reset
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

        }
    }
}