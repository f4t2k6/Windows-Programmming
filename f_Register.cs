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
    public partial class f_Register : Form
    {
        // Biến nhận giá trị position truyền từ f_Login sang (1 = Student, 2 = HR)
        private int position;

        public f_Register(int rolePosition)
        {
            InitializeComponent();
            this.position = rolePosition;
        }

        private void f_Register_Load(object sender, EventArgs e)
        {
            // Tông màu tối giản professional (White - Black - Blue) đồng bộ hệ thống
            this.BackColor = SystemColors.ControlLightLight;

            // Hiển thị vai trò đang đăng ký trên thanh tiêu đề để người dùng biết
            if (position == 2)
                this.Text = "Đăng Ký Tài Khoản Quản Lý (HR)";
            else
                this.Text = "Đăng Ký Tài Khoản Sinh Viên (Student)";
        }

        // =========================================================
        // SỰ KIỆN NHẤN NÚT ĐĂNG KÝ
        // =========================================================
        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (!verif()) return;

            // CHỐT CHẶN WHITELIST CHO SINH VIÊN
            if (position == 1) // Diện Student
            {
                int mssvCheck = Convert.ToInt32(txb_MSGV.Text.Trim());
                string emailCheck = txb_Email.Text.Trim();

                if (!CheckStudentWhitelist(mssvCheck, emailCheck))
                {
                    MessageBox.Show("Mã số sinh viên hoặc Email không trùng khớp với danh sách nhà trường cấp! Vui lòng liên hệ phòng đào tạo.",
                                    "Từ chối đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (existUser() == false) { MessageBox.Show("Tên tài khoản này đã tồn tại!"); return; }
            if (existEmail() == false) { MessageBox.Show("Email này đã được sử dụng!"); return; }

            f_OTP otp = new f_OTP();
            otp.to = txb_Email.Text.Trim();
            this.Hide();

            if (otp.ShowDialog() == DialogResult.OK)
            {
                if (RegisterAccount())
                {
                    // THÔNG BÁO THÔNG MINH THEO VAI TRÒ
                    if (position == 2)
                    {
                        MessageBox.Show("Đăng ký thành công! Đã gửi yêu cầu cấp quyền. Vui lòng chờ Admin phê duyệt kích hoạt tài khoản HR.",
                                        "Hệ Thống Chờ Duyệt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xác thực thành công! Tài khoản sinh viên của bạn đã kích hoạt. Bạn có thể đăng nhập ngay bấy giờ.",
                                        "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi ghi nhận dữ liệu.");
                    this.Show();
                }
            }
            else { this.Show(); }
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

                // =========================================================
                // LUỒNG 1: ĐĂNG KÝ CHO DIỆN QUẢN LÝ (HR)
                // =========================================================
                if (position == 2)
                {
                    // TUYỆT ĐỐI KHÔNG insert vào bảng login. Chỉ lưu hồ sơ + pass vào bảng phòng chờ register_HR
                    string queryHR = "INSERT INTO register_HR (Id, Username, Password, Fname, Lname, Email, Picture) " +
                                     "VALUES (@id, @user, @pass, @fname, @lname, @email, @pic)";

                    SqlCommand cmdHR = new SqlCommand(queryHR, my_db.conn);
                    cmdHR.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(txb_MSGV.Text.Trim());
                    cmdHR.Parameters.Add("@user", SqlDbType.VarChar).Value = txb_User.Text.Trim();
                    cmdHR.Parameters.Add("@pass", SqlDbType.VarChar).Value = ComputeSHA256(txb_Pass.Text); // Lưu pass tạm ở đây
                    cmdHR.Parameters.Add("@fname", SqlDbType.NVarChar).Value = txb_Fname.Text.Trim();
                    cmdHR.Parameters.Add("@lname", SqlDbType.NVarChar).Value = txb_Lname.Text.Trim();
                    cmdHR.Parameters.Add("@email", SqlDbType.VarChar).Value = txb_Email.Text.Trim();

                    MemoryStream ms = new MemoryStream();
                    ptb_Picture.Image.Save(ms, ptb_Picture.Image.RawFormat);
                    cmdHR.Parameters.Add("@pic", SqlDbType.Image).Value = ms.ToArray();

                    int rowsHR = cmdHR.ExecuteNonQuery();
                    return rowsHR > 0; // Trả về true nếu lưu phòng chờ thành công
                }
                // =========================================================
                // LUỒNG 2: ĐĂNG KÝ CHO DIỆN SINH VIÊN (STUDENT)
                // =========================================================
                else
                {
                    // Vì thông tin cá nhân của sinh viên ĐÃ CÓ SẴN trong bảng Student (do nhà trường nạp trước),
                    // ta CHỈ CẦN cấp tài khoản đăng nhập bằng cách insert thẳng dữ liệu vào bảng login.
                    string queryLogin = "INSERT INTO login (Id, username, password, role, email) VALUES (@id, @user, @pass, @pos, @email)";

                    SqlCommand cmdLogin = new SqlCommand(queryLogin, my_db.conn);
                    cmdLogin.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(txb_MSGV.Text.Trim());
                    cmdLogin.Parameters.Add("@user", SqlDbType.VarChar).Value = txb_User.Text.Trim();
                    cmdLogin.Parameters.Add("@pass", SqlDbType.VarChar).Value = ComputeSHA256(txb_Pass.Text);
                    cmdLogin.Parameters.Add("@pos", SqlDbType.VarChar).Value = "Student";
                    cmdLogin.Parameters.Add("@email", SqlDbType.VarChar).Value = txb_Email.Text.Trim();

                    // (Tùy chọn nâng cao): Cập nhật luôn ảnh đại diện mà sinh viên vừa tải lên vào hồ sơ gốc trong bảng Student
                    string queryUpdatePic = "UPDATE Student SET Pture = @pic WHERE MSSV = @id";
                    SqlCommand cmdUpdatePic = new SqlCommand(queryUpdatePic, my_db.conn);
                    cmdUpdatePic.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(txb_MSGV.Text.Trim());

                    MemoryStream ms = new MemoryStream();
                    ptb_Picture.Image.Save(ms, ptb_Picture.Image.RawFormat);
                    cmdUpdatePic.Parameters.Add("@pic", SqlDbType.Image).Value = ms.ToArray();

                    int rowsLogin = cmdLogin.ExecuteNonQuery();
                    cmdUpdatePic.ExecuteNonQuery(); // Đồng bộ ảnh đại diện vào hồ sơ sinh viên

                    return rowsLogin > 0; // Sinh viên được phép hoạt động ngay lập tức
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi dữ liệu đăng ký: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                my_db.closeConnection();
            }
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
                return count == 0; // Trả về true nếu count = 0 (Tài khoản chưa từng tồn tại -> Hợp lệ)
            }
            catch { return false; }
            finally { my_db.closeConnection(); }
        }

        // Kiểm tra email không được trùng lặp ở cả 2 bảng
        private bool existEmail()
        {
            MY_DB my_db = new MY_DB();

            string query = "SELECT COUNT(*) FROM (" +
                           "SELECT Email FROM login WHERE Email = @email " +
                           "UNION ALL " +
                           "SELECT Email FROM register_HR WHERE Email = @email" +
                           ") as EmailTable";

            SqlCommand cmd = new SqlCommand(query, my_db.conn);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txb_Email.Text.Trim();

            try
            {
                my_db.openConnection();
                int count = (int)cmd.ExecuteScalar();
                return count == 0; // Trả về true nếu chưa có ai đăng ký email này
            }
            catch { return false; }
            finally { my_db.conn.Close(); }
        }

        // Hàm kiểm tra định dạng và dữ liệu hợp lệ toàn diện (Validation)
        private bool verif()
        {

            // 1. Kiểm tra rỗng (Đã bổ sung txb_ConfirmPass)
            if (string.IsNullOrWhiteSpace(txb_MSGV.Text) ||
                string.IsNullOrWhiteSpace(txb_Fname.Text) ||
                string.IsNullOrWhiteSpace(txb_Lname.Text) ||
                string.IsNullOrWhiteSpace(txb_User.Text) ||
                string.IsNullOrWhiteSpace(txb_Pass.Text) ||
                string.IsNullOrWhiteSpace(txb_ConfirmPass.Text) ||
                string.IsNullOrWhiteSpace(txb_Email.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các thông tin bắt buộc (Bao gồm cả Xác nhận mật khẩu)!", "Dữ liệu thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ptb_Picture_Click(object sender, EventArgs e)
        {

        }

        // Sự kiện TextChanged cho ô Confirm Password (Xác nhận realtime)
        private void txb_ConfirmPass_TextChanged(object sender, EventArgs e)
        {
            // Nếu ô xác nhận đang trống thì ẩn thông báo đi
            if (string.IsNullOrEmpty(txb_ConfirmPass.Text))
            {
                lbl_PassStatus.Text = "";
                return;
            }

            // So sánh khớp hay không
            if (txb_ConfirmPass.Text == txb_Pass.Text)
            {
                lbl_PassStatus.Text = "Mật khẩu khớp!";
                lbl_PassStatus.ForeColor = Color.Green;
            }
            else
            {
                lbl_PassStatus.Text = "Mật khẩu chưa khớp!";
                lbl_PassStatus.ForeColor = Color.Red;
            }
        }

        private void txb_Pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ptb_ShowConfirmPass_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem mật khẩu đang bị che hay đang hiện
            // Lưu ý: Chữ '●' là ký tự che mật khẩu bạn đang dùng trong code, 
            // nếu bạn dùng dấu '*' thì sửa lại thành '*' nhé.

            if (txb_ConfirmPass.PasswordChar == '●')
            {
                // 1. Nếu đang bị che -> Chuyển sang HỆN mật khẩu
                txb_ConfirmPass.PasswordChar = '\0'; // '\0' là ký tự rỗng, giúp TextBox hiện chữ bình thường

                // (Tùy chọn) Đổi ảnh con mắt thành con mắt bị gạch chéo 
                // ptb_ShowConfirmPass.Image = Image.FromFile("đường_dẫn_tới_ảnh_mắt_nhắm.png");
            }
            else
            {
                // 2. Nếu đang hiện -> Chuyển sang CHE mật khẩu
                txb_ConfirmPass.PasswordChar = '●';

                // (Tùy chọn) Đổi ảnh con mắt lại thành mắt mở
                // ptb_ShowConfirmPass.Image = Image.FromFile("đường_dẫn_tới_ảnh_mắt_mở.png");
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

        private void txb_Lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_Lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private bool CheckStudentWhitelist(int mssv, string email)
        {
            MY_DB my_db = new MY_DB();
            // Đối chiếu chính xác xem MSSV này có đi kèm với Email đăng ký này trong danh sách trường không
            string query = "SELECT COUNT(*) FROM Student WHERE MSSV = @id AND Email = @email";
            SqlCommand cmd = new SqlCommand(query, my_db.conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = mssv;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

            try
            {
                my_db.openConnection();
                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Trả về true nếu sinh viên hợp lệ hợp pháp
            }
            catch { return false; }
            finally { my_db.closeConnection(); }
        }
    }
}