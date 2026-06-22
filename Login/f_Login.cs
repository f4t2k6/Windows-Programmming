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

            SetupFaceLoginButton();
        }

        private void SetupFaceLoginButton()
        {
            Button btnFaceLogin = new Button();
            btnFaceLogin.BackColor = Color.SeaGreen;
            btnFaceLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFaceLogin.ForeColor = Color.White;
            btnFaceLogin.Text = "Face Login";
            btnFaceLogin.FlatStyle = FlatStyle.Flat;
            btnFaceLogin.FlatAppearance.BorderSize = 0;
            
            // Adjust original button and place this one next to it
            button_Dangnhap.Size = new Size(220, 68);
            btnFaceLogin.Location = new Point(253, 366);
            btnFaceLogin.Size = new Size(220, 68);
            
            btnFaceLogin.Click += BtnFaceLogin_Click;
            panel_Login.Controls.Add(btnFaceLogin);
        }

        private void BtnFaceLogin_Click(object? sender, EventArgs e)
        {
            var faceLoginForm = new ProjectMonHoc.Login.f_FaceLogin();
            if (faceLoginForm.ShowDialog() == DialogResult.OK)
            {
                string username = faceLoginForm.LoggedInUsername;
                // Query database to get role and auto login
                PerformFaceLoginAction(username);
            }
        }

        private void PerformFaceLoginAction(string username)
        {
            MY_DB my_db = new MY_DB();
            try
            {
                my_db.openConnection();
                string sql = "SELECT Id, role, email FROM login WHERE username = @user";
                SqlCommand command = new SqlCommand(sql, my_db.conn);
                command.Parameters.Add("@user", System.Data.SqlDbType.VarChar).Value = username;
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["Id"]);
                        string roleStr = reader["role"].ToString() ?? "";
                        string email = reader["email"].ToString() ?? "";
                        
                        reader.Close(); // Close before executing another query in FetchFullName
                        string fullName = FetchFullName(my_db, userId, roleStr);
                        
                        Globals.SetSession(userId, username, roleStr, email, fullName);
                        
                        if (roleStr == "Student")
                        {
                            this.Hide();
                            f_MainStudent formStudent = new f_MainStudent();
                            formStudent.ShowDialog();
                            this.Close();
                        }
                        else if (roleStr == "HR")
                        {
                            this.Hide();
                            f_MainHR formHR = new f_MainHR();
                            formHR.ShowDialog();
                            this.Close();
                        }
                        else if (roleStr == "Admin")
                        {
                            this.Hide();
                            f_MainAdmin formAdmin = new f_MainAdmin();
                            formAdmin.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL khi Face Login: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                my_db.closeConnection();
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
                string selectQuery = "SELECT Id, username, password, role, email, ISNULL(LoginAttempts, 0) AS LoginAttempts, TwoFactorSecret " +
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
                    string email = row["email"].ToString() ?? "";

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

                        // Kiểm tra 2FA
                        string twoFactorSecret = row["TwoFactorSecret"].ToString()?.Trim() ?? "";
                        if (!string.IsNullOrEmpty(twoFactorSecret))
                        {
                            f_TOTPVerify verifyForm = new f_TOTPVerify(username, twoFactorSecret);
                            if (verifyForm.ShowDialog() != DialogResult.OK)
                            {
                                MessageBox.Show("Xác thực 2 yếu tố thất bại hoặc bị hủy. Không thể đăng nhập.", "Xác Thực Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // Thiết lập Session toàn cục (username, role, email từ bảng login)
                        // Query thêm Họ Tên đầy đủ từ bảng HR hoặc Student — chỉ 1 lần duy nhất
                        string fullName = FetchFullName(my_db, userId, roleStr);
                        Globals.SetSession(
                            id:       userId,
                            username: row["username"].ToString() ?? "",
                            role:     row["role"].ToString() ?? "",
                            email:    row["email"].ToString() ?? "",
                            fullName: fullName
                        );

                        // Xử lý AI Login Behavior Logging
                        _ = LogAndAnalyzeLoginAsync(username, "Success", email);

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
                        // Hiện thông báo chào mừng TRƯỚC (f_Login vẫn còn hiển thị)
                        // Chỉ sau khi người dùng nhấn OK thì mới ẩn f_Login và mở form chính

                        if (roleStr == "Student")
                        {
                            MessageBox.Show("Đăng nhập thành công với quyền Sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide(); // Ẩn form đăng nhập SAU KHI nhấn OK
                            f_MainStudent formStudent = new f_MainStudent();
                            formStudent.ShowDialog();
                        }
                        else if (roleStr == "HR")
                        {
                            // Kiểm tra tài khoản Admin mặc định (mật khẩu gốc nhập vào là 12345)
                            if (username == "Admin" && textBox_Matkhau.Text == "12345")
                            {
                                MessageBox.Show("Chào mừng Quản trị viên (Admin) hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide(); // Ẩn form đăng nhập SAU KHI nhấn OK
                                f_MainAdmin formAdmin = new f_MainAdmin();
                                formAdmin.ShowDialog();
                            }
                            else
                            {
                                // Tài khoản HR thường (Để trống chờ làm Form riêng)
                                MessageBox.Show("Chào mừng HR!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Hide(); // Ẩn form đăng nhập SAU KHI nhấn OK
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
                        // Log failed login
                        _ = LogAndAnalyzeLoginAsync(username, "Failed", row["email"].ToString() ?? "");

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

        private async System.Threading.Tasks.Task LogAndAnalyzeLoginAsync(string username, string status, string userEmail)
        {
            try
            {
                // 1. Lưu log vào Database
                using (var db = new MY_DB())
                {
                    db.openConnection();
                    string insertSql = "INSERT INTO LoginLogs (Username, Status, AttemptTime) VALUES (@user, @status, GETDATE())";
                    using (var cmd = new SqlCommand(insertSql, db.conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Kiểm tra điều kiện Trigger AI
                    int failedAttemptsLast15Mins = 0;
                    string countSql = "SELECT COUNT(*) FROM LoginLogs WHERE Username = @user AND Status LIKE 'Failed%' AND AttemptTime >= DATEADD(MINUTE, -15, GETDATE())";
                    using (var cmdCount = new SqlCommand(countSql, db.conn))
                    {
                        cmdCount.Parameters.AddWithValue("@user", username);
                        failedAttemptsLast15Mins = Convert.ToInt32(cmdCount.ExecuteScalar());
                    }

                    int currentHour = DateTime.Now.Hour;
                    bool isAbnormalHour = (currentHour >= 1 && currentHour <= 5);

                    if (failedAttemptsLast15Mins >= 3 || isAbnormalHour)
                    {
                        // Gom 10 log gần nhất
                        System.Collections.Generic.List<string> recentLogs = new System.Collections.Generic.List<string>();
                        string logQuery = "SELECT TOP 10 Status, AttemptTime FROM LoginLogs WHERE Username = @user ORDER BY AttemptTime DESC";
                        using (var cmdLog = new SqlCommand(logQuery, db.conn))
                        {
                            cmdLog.Parameters.AddWithValue("@user", username);
                            using (var dr = cmdLog.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    recentLogs.Add($"{dr["AttemptTime"]}: {dr["Status"]}");
                                }
                            }
                        }

                        // Gọi AI
                        var analyzer = new ProjectMonHoc.Classes.AILoginAnalyzer();
                        var aiResult = await analyzer.AnalyzeLoginBehaviorAsync(username, recentLogs);

                        if (aiResult.IsAbnormal && !string.IsNullOrEmpty(userEmail))
                        {
                            // Update Reason
                            string updateSql = "UPDATE LoginLogs SET Reason = @reason WHERE Id = (SELECT TOP 1 Id FROM LoginLogs WHERE Username = @user ORDER BY AttemptTime DESC)";
                            using (var cmdUpdate = new SqlCommand(updateSql, db.conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@reason", aiResult.Reason);
                                cmdUpdate.Parameters.AddWithValue("@user", username);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            // Gửi Email
                            var emailService = new ProjectMonHoc.Classes.EmailService();
                            string subject = "Cảnh báo Đăng nhập Bất thường UTEID";
                            string body = $@"<h3>Hệ thống phát hiện hành vi đáng ngờ</h3>
                                            <p>Tài khoản: <b>{username}</b></p>
                                            <p>Phân tích từ AI: <b>{aiResult.Reason}</b></p>
                                            <p>Nếu bạn không thực hiện đăng nhập này, vui lòng đổi mật khẩu ngay lập tức.</p>";
                            await emailService.SendWarningEmailAsync(userEmail, subject, body);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi Log & Analyze: " + ex.Message);
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

        /// <summary>
        /// Lấy Họ và Tên đầy đủ từ bảng HR (cột Fname + Lname theo MSGV)
        /// hoặc bảng Student (cột Fname + Lname theo MSSV) tùy theo role.
        /// Dùng lại connection đã mở sẵn — không tốn thêm kết nối mới.
        /// Trả về chuỗi rỗng nếu không tìm thấy hoặc xảy ra lỗi.
        /// </summary>
        private static string FetchFullName(MY_DB db, int userId, string role)
        {
            try
            {
                string sql;
                if (role == "HR")
                    // Bảng HR dùng cột MSGV (kiểu nvarchar) để định danh
                    sql = "SELECT ISNULL(Fname,'') + ' ' + ISNULL(Lname,'') FROM HR WHERE MSGV = @id";
                else
                    // Bảng Student dùng cột MSSV (kiểu int)
                    sql = "SELECT ISNULL(Fname,'') + ' ' + ISNULL(Lname,'') FROM Student WHERE MSSV = @id";

                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@id", userId);
                object result = cmd.ExecuteScalar();

                string name = (result != null && result != DBNull.Value)
                    ? result.ToString()!.Trim()
                    : "";

                // Nếu query không trả về gì (Admin, hoặc chưa có hồ sơ) thì dùng username
                return string.IsNullOrEmpty(name) ? Globals.GlobalUsername : name;
            }
            catch
            {
                // Không làm gián đoạn quá trình đăng nhập nếu query phụ bị lỗi
                return "";
            }
        }


    }
}