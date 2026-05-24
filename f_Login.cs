using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    public partial class f_Login : Form
    {
        private int position;

        public f_Login()
        {
            InitializeComponent();
        }

        // Tải lại tên đăng nhập đã ghi nhớ (nếu có) khi form load
        private void f_Login_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SavedUsername))
            {
                txb_User.Text = Properties.Settings.Default.SavedUsername;
                chk_Remember.Checked = true;
            }
        }

        // Hàm băm mật khẩu SHA-256 chuyển thành chuỗi Hex (64 ký tự)
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

        // =========================================================
        // ĐĂNG NHẬP
        // =========================================================
        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            position = rdb_HR.Checked ? 2 : 1;
            string roleStr = (position == 2) ? "HR" : "Student";
            string username = txb_User.Text.Trim();
            string inputPasswordHash = ComputeSHA256(txb_Pass.Text); // Băm mật khẩu nhập vào

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
                        if (chk_Remember.Checked)
                        {
                            Properties.Settings.Default.SavedUsername = username;
                        }
                        else
                        {
                            Properties.Settings.Default.SavedUsername = string.Empty;
                        }
                        Properties.Settings.Default.Save(); // Lưu lại thay đổi vào file cấu hình

                        // =========================================================
                        // BƯỚC 4: LOGIC ĐIỀU HƯỚNG THEO ROLE (THAY THẾ DialogResult.OK)
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
                            if (username == "Admin" && txb_Pass.Text == "12345")
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
                        // Nếu muốn thoát hẳn app khi đóng form chính, đổi this.Show() thành Application.Exit()
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
                            errorProvider1.SetError(txb_Pass, $"Sai mật khẩu! Bạn còn {remainingAttempts} lần thử.");
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
                    errorProvider1.SetError(txb_Pass, "Sai tên đăng nhập hoặc mật khẩu!");
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

        // =========================================================
        // VALIDATION REALTIME
        // =========================================================
        private bool ValidateInputs()
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txb_User.Text))
            {
                errorProvider1.SetError(txb_User, "Vui lòng nhập tài khoản!");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txb_Pass.Text))
            {
                errorProvider1.SetError(txb_Pass, "Vui lòng nhập mật khẩu!");
                valid = false;
            }

            return valid;
        }

        private void txb_User_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txb_User,
                txb_User.Text.Trim() == "" ? "Vui lòng nhập tài khoản!" : "");
        }

        private void txb_Pass_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txb_Pass,
                txb_Pass.Text == "" ? "Vui lòng nhập mật khẩu!" : "");
        }

        // =========================================================
        // HỦY
        // =========================================================
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void llbl_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Lấy trạng thái vai trò hiện tại mà người dùng đang chọn trên Form Login
            // (1 = Student nếu rdb_Student được tích, 2 = HR nếu rdb_HR được tích)
            int currentRolePosition = rdb_HR.Checked ? 2 : 1;

            // Khởi tạo Form Đăng ký và truyền giá trị vai trò sang
            f_Register registerForm = new f_Register(currentRolePosition);

            // Ẩn form đăng nhập hiện tại đi
            this.Hide();

            // Hiển thị form đăng ký dưới dạng hộp thoại
            registerForm.ShowDialog();

            // Sau khi người dùng đóng form Đăng ký, hiển thị lại Form đăng nhập ban đầu
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void llbl_ForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Lấy Role hiện tại dựa trên RadioButton
            int currentRole = rdb_HR.Checked ? 2 : 1;

            // Khởi tạo f_ForgotPass và truyền Role vào
            f_ForgetPass frmForgot = new f_ForgetPass(currentRole);

            this.Hide();
            frmForgot.ShowDialog();
            this.Show(); // Hiện lại Login sau khi quá trình kết thúc
        }

        private void rdb_HR_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}