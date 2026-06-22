using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_Register : Form
    {
        // Biến nhận giá trị position truyền từ f_Login sang (1 = Student, 2 = HR)

        private f_Login loginForm;
        private string savedMSSV = "";
        private string savedUsername = "";
        private string savedPassword = "";
        private string savedFname = "";
        private string savedLname = "";
        private string savedEmail = "";
        private Image? savedImage = null;
        private int position;
        public Action? onDone { get; set; }
        private bool _registrationDone = false;
        private bool _hasPendingRestore = false;

        public f_Register(int rolePosition, f_Login loginForm)
        {
            InitializeComponent();
            this.position = rolePosition;
            this.loginForm = loginForm;
        }

        // =========================================================
        // KHÔI PHỤC DỮ LIỆU ĐÃ NHẬP (khi người dùng nhấn Hủy ở f_OTP
        // và quay lại f_Register) — gọi hàm này TRƯỚC khi form được
        // hiển thị (trước OpenChildForm), để các TextBox không bị trống.
        // =========================================================
        public void RestoreFormData(string mssv, string username, string password,
                                     string fname, string lname, string email, Image? image)
        {
            savedMSSV = mssv;
            savedUsername = username;
            savedPassword = password;
            savedFname = fname;
            savedLname = lname;
            savedEmail = email;
            savedImage = image;
            _hasPendingRestore = true;
        }

        private void f_Register_Load(object sender, EventArgs e)
        {
            // Tông màu tối giản professional (White - Black - Blue) đồng bộ hệ thống
            this.BackColor = SystemColors.ControlLightLight;

            // Hiển thị vai trò đang đăng ký trên thanh tiêu đề để người dùng biết
            if (position == 2)
                lbl_Header.Text = "ĐĂNG KÝ TÀI KHOẢN HR";
            else
                lbl_Header.Text = "ĐĂNG KÝ TÀI KHOẢN STUDENT";

            // Mặc định cả 2 ô mật khẩu đang ẩn -> icon hiển thị "eye_open" (gợi ý bấm để xem)
            ptb_ShowPass.Image = Properties.Resources.eye_open;
            ptb_ShowConfirmPass.Image = Properties.Resources.eye_open;

            // ✅ Nếu đây là form được mở lại sau khi người dùng nhấn "Hủy" ở f_OTP,
            //    điền lại toàn bộ dữ liệu đã nhập trước đó để người dùng không phải nhập lại từ đầu.
            if (_hasPendingRestore)
            {
                txb_MSGV.Text = savedMSSV;
                txb_User.Text = savedUsername;
                txb_Pass.Text = savedPassword;
                txb_ConfirmPass.Text = savedPassword;
                txb_Fname.Text = savedFname;
                txb_Lname.Text = savedLname;
                txb_Email.Text = savedEmail;
                if (savedImage != null)
                    ptb_Picture.Image = savedImage;

                UpdatePassMatchStatus();
                _hasPendingRestore = false;
            }
        }

        // =========================================================
        // SỰ KIỆN NHẤN NÚT ĐĂNG KÝ
        // =========================================================
        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (!verif()) return;

            if (position == 1)
            {
                int mssvCheck = Convert.ToInt32(txb_MSGV.Text.Trim());
                string emailCheck = txb_Email.Text.Trim();
                if (!CheckStudentWhitelist(mssvCheck, emailCheck))
                {
                    MessageBox.Show("Mã số sinh viên hoặc Email không trùng khớp...",
                                    "Từ chối đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (existUser() == false) { MessageBox.Show("Tên tài khoản này đã tồn tại!"); return; }
            if (existEmail() == false) { MessageBox.Show("Email này đã được sử dụng!"); return; }

            // ✅ Lưu toàn bộ dữ liệu vào biến TRƯỚC khi mở OTP
            // (vì sau khi panel chuyển sang f_OTP, các TextBox không còn đọc được nữa)
            savedMSSV = txb_MSGV.Text.Trim();
            savedUsername = txb_User.Text.Trim();
            savedPassword = txb_Pass.Text;
            savedFname = txb_Fname.Text.Trim();
            savedLname = txb_Lname.Text.Trim();
            savedEmail = txb_Email.Text.Trim();
            savedImage = ptb_Picture.Image;

            f_OTP otp = new f_OTP();
            otp.to = savedEmail;

            // Trong btn_Register_Click, sửa lại FormClosed handler:
            otp.FormClosed += (s, args) =>
            {
                if (_registrationDone) return;

                if (otp.DialogResult == DialogResult.OK)
                {
                    if (RegisterAccount())
                    {
                        _registrationDone = true;

                        if (position == 2)
                            MessageBox.Show("Đăng ký thành công! Vui lòng chờ Admin phê duyệt.",
                                            "Hệ Thống Chờ Duyệt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Xác thực thành công! Tài khoản đã kích hoạt.",
                                            "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        onDone?.Invoke(); // Quay về login
                    }
                    else
                    {
                        MessageBox.Show("Lỗi ghi nhận dữ liệu.");
                        onDone?.Invoke(); // ← SỬA: dùng onDone thay vì OpenChildForm(this,...)
                    }
                }
                else
                {
                    // ✅ Người dùng nhấn Hủy ở f_OTP -> quay lại f_Register
                    //    Tạo instance mới (vì form cũ đã bị disposed khi chuyển panel)
                    //    nhưng KHÔI PHỤC lại toàn bộ dữ liệu đã nhập trước đó
                    //    bằng cách truyền các giá trị đã lưu (savedXXX) qua constructor.
                    f_Register newRegister = new f_Register(position, loginForm)
                    {
                        onDone = onDone
                    };
                    newRegister.RestoreFormData(savedMSSV, savedUsername, savedPassword,
                                                 savedFname, savedLname, savedEmail, savedImage);

                    loginForm.OpenChildForm(newRegister, loginForm.LoginPanel);
                }
            };

            loginForm.OpenChildForm(otp, loginForm.LoginPanel);
        }

        // =========================================================
        // LỆNH LƯU TÀI KHOẢN VÀO CƠ SỞ DỮ LIỆU
        // =========================================================
        private bool RegisterAccount()
        {
            MY_DB my_db = new MY_DB();
            try
            {
                my_db.openConnection();

                if (position == 2)
                {
                    string queryHR = "INSERT INTO register_HR (Id, Username, Password, Fname, Lname, Email, Picture, Status) " +
                                     "VALUES (@id, @user, @pass, @fname, @lname, @email, @pic, 0)";
                    SqlCommand cmdHR = new SqlCommand(queryHR, my_db.conn);
                    cmdHR.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(savedMSSV);
                    cmdHR.Parameters.Add("@user", SqlDbType.VarChar).Value = savedUsername;
                    cmdHR.Parameters.Add("@pass", SqlDbType.VarChar).Value = ComputeSHA256(savedPassword);
                    cmdHR.Parameters.Add("@fname", SqlDbType.NVarChar).Value = savedFname;
                    cmdHR.Parameters.Add("@lname", SqlDbType.NVarChar).Value = savedLname;
                    cmdHR.Parameters.Add("@email", SqlDbType.VarChar).Value = savedEmail;

                    MemoryStream ms = new MemoryStream();
                    savedImage!.Save(ms, savedImage.RawFormat);
                    cmdHR.Parameters.Add("@pic", SqlDbType.Image).Value = ms.ToArray();

                    return cmdHR.ExecuteNonQuery() > 0;
                }
                else
                {
                    string queryLogin = "INSERT INTO login (Id, username, password, role, email) " +
                                        "VALUES (@id, @user, @pass, @pos, @email)";
                    SqlCommand cmdLogin = new SqlCommand(queryLogin, my_db.conn);
                    cmdLogin.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(savedMSSV);
                    cmdLogin.Parameters.Add("@user", SqlDbType.VarChar).Value = savedUsername;
                    cmdLogin.Parameters.Add("@pass", SqlDbType.VarChar).Value = ComputeSHA256(savedPassword);
                    cmdLogin.Parameters.Add("@pos", SqlDbType.VarChar).Value = "Student";
                    cmdLogin.Parameters.Add("@email", SqlDbType.VarChar).Value = savedEmail;

                    string queryUpdatePic = "UPDATE Student SET Pture = @pic WHERE MSSV = @id";
                    SqlCommand cmdUpdatePic = new SqlCommand(queryUpdatePic, my_db.conn);
                    cmdUpdatePic.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(savedMSSV);

                    MemoryStream ms = new MemoryStream();
                    savedImage!.Save(ms, savedImage.RawFormat);
                    cmdUpdatePic.Parameters.Add("@pic", SqlDbType.Image).Value = ms.ToArray();

                    int rows = cmdLogin.ExecuteNonQuery();
                    cmdUpdatePic.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi dữ liệu đăng ký: " + ex.Message, "Lỗi SQL",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { my_db.closeConnection(); }
        }

        // =========================================================
        // LOGIC KIỂM TRA ĐIỀU KIỆN ĐĂNG KÝ
        // =========================================================

        // Kiểm tra username không được trùng lặp ở cả 2 bảng
        private bool existUser()
        {
            MY_DB my_db = new MY_DB();

            // Dùng UNION câu lệnh độc lập để đếm chính xác, loại bỏ lỗi Cross Join
            string query = "SELECT COUNT(*) FROM (" +
                           "SELECT username FROM login WHERE username = @user " +
                           "UNION ALL " +
                           "SELECT Username FROM register_HR WHERE Username = @user" +
                           ") as AccountTable";

            SqlCommand cmd = new SqlCommand(query, my_db.conn);
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txb_User.Text.Trim();

            try
            {
                my_db.openConnection();
                int count = (int)cmd.ExecuteScalar();
                return count == 0; // Trả về true nếu chưa tồn tại (được phép đăng ký)
            }
            catch { return false; }
            finally { my_db.closeConnection(); }
        }

        // Kiểm tra email không được trùng lặp ở cả 2 bảng
        private bool existEmail()
        {
            MY_DB my_db = new MY_DB();

            string query = "SELECT COUNT(*) FROM (" +
                           "SELECT email FROM login WHERE email = @email " +
                           "UNION ALL " +
                           "SELECT Email FROM register_HR WHERE Email = @email" +
                           ") as EmailTable";

            SqlCommand cmd = new SqlCommand(query, my_db.conn);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txb_Email.Text.Trim();

            try
            {
                my_db.openConnection();
                int count = (int)cmd.ExecuteScalar();
                return count == 0; // Trả về true nếu email chưa tồn tại
            }
            catch { return false; }
            finally { my_db.closeConnection(); }
        }

        private bool verif()
        {
            // 1. Kiểm tra các trường bắt buộc không được để trống
            if (string.IsNullOrWhiteSpace(txb_User.Text) ||
                string.IsNullOrWhiteSpace(txb_Pass.Text) ||
                string.IsNullOrWhiteSpace(txb_ConfirmPass.Text) ||
                string.IsNullOrWhiteSpace(txb_Email.Text) ||
                string.IsNullOrWhiteSpace(txb_MSGV.Text) ||
                string.IsNullOrWhiteSpace(txb_Fname.Text) ||
                string.IsNullOrWhiteSpace(txb_Lname.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Kiểm tra MSGV/MSSV phải là số nguyên
            if (!int.TryParse(txb_MSGV.Text.Trim(), out _))
            {
                MessageBox.Show("Mã số (ID) phải là một chuỗi ký tự số!", "Dữ liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 3. Kiểm tra định dạng Email chuẩn bằng Regex
            string emailPattern = @"^[^@\s]+@gmail\.com$";
            if (!Regex.IsMatch(txb_Email.Text.Trim(), emailPattern))
            {
                MessageBox.Show("Định dạng Email không đúng quy định! Vui lòng kiểm tra lại.", "Dữ liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 4. KIỂM TRA ĐỘ MẠNH MẬT KHẨU (Nâng cao)
            if (!IsStrongPassword(txb_Pass.Text))
            {
                MessageBox.Show("Mật khẩu quá yếu!\nYêu cầu: Tối thiểu 8 ký tự, gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt (@, $, !, %, *, ?, &).",
                                "Mật khẩu không an toàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 5. KIỂM TRA XÁC NHẬN MẬT KHẨU (Nâng cao)
            if (txb_Pass.Text != txb_ConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp với mật khẩu đã nhập!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 6. Kiểm tra ảnh đại diện
            if (ptb_Picture.Image == null)
            {
                MessageBox.Show("Vui lòng tải ảnh đại diện lên để đăng ký thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Hàm tiện ích băm mật khẩu SHA-256 đồng bộ hóa bảo mật đăng nhập
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

        // Hàm kiểm tra độ mạnh mật khẩu bằng Regex
        private bool IsStrongPassword(string password)
        {
            // Yêu cầu: Tối thiểu 8 ký tự, ít nhất 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        // Nút chọn ảnh đại diện từ máy tính
        private void btn_UploadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ptb_Picture.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void ptb_Picture_Click(object sender, EventArgs e) { }

        // Sự kiện TextChanged cho ô Confirm Password (Xác nhận realtime)
        private void txb_ConfirmPass_TextChanged(object sender, EventArgs e)
        {
            UpdatePassMatchStatus();
        }

        private void txb_Fname_TextChanged(object sender, EventArgs e) { }
        private void txb_Pass_TextChanged(object sender, EventArgs e)
        {
            UpdatePassMatchStatus();
        }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        // Cập nhật dấu tích xanh (khớp) hoặc dấu X đỏ (chưa khớp) kế bên ô Nhập lại mật khẩu
        private void UpdatePassMatchStatus()
        {
            if (string.IsNullOrEmpty(txb_ConfirmPass.Text))
            {
                lbl_PassStatus.Visible = false;
                return;
            }

            lbl_PassStatus.Visible = true;
            if (txb_ConfirmPass.Text == txb_Pass.Text)
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

        private void ptb_ShowPass_Click(object sender, EventArgs e)
        {
            if (txb_Pass.PasswordChar == '●')
            {
                txb_Pass.PasswordChar = '\0';
                ptb_ShowPass.Image = Properties.Resources.eye_close;
            }
            else
            {
                txb_Pass.PasswordChar = '●';
                ptb_ShowPass.Image = Properties.Resources.eye_open;
            }
        }

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

        private void txb_MSGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txb_Fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txb_Lname_TextChanged(object sender, EventArgs e) { }

        private void txb_Lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private bool CheckStudentWhitelist(int mssv, string email)
        {
            MY_DB my_db = new MY_DB();
            string query = "SELECT COUNT(*) FROM Student WHERE MSSV = @id AND Email = @email";
            SqlCommand cmd = new SqlCommand(query, my_db.conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = mssv;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

            try
            {
                my_db.openConnection();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch { return false; }
            finally { my_db.closeConnection(); }
        }

        private void lbl_Header_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Register_Click(object sender, EventArgs e)
        {
            onDone?.Invoke();
        }
    }
}