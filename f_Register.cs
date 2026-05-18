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
            // 1. Kiểm tra tính hợp lệ của dữ liệu nhập vào (Đầy đủ, đúng định dạng số, đúng regex email)
            if (!verif()) return;

            // 2. Kiểm tra tên tài khoản đã tồn tại chưa (Bỏ dấu '!' để nếu trùng -> Trả về false -> !false thành true -> Báo lỗi)
            if (existUser() == false)
            {
                MessageBox.Show("Tên tài khoản này đã tồn tại trên hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Kiểm tra Email đã được đăng ký chưa (Bỏ dấu '!' để nếu trùng -> Trả về false -> !false thành true -> Báo lỗi)
            if (existEmail() == false)
            {
                MessageBox.Show("Email này đã được sử dụng bởi một tài khoản khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Nếu mọi điều kiện hợp lệ, tiến hành gọi form OTP xác thực email
            f_OTP otp = new f_OTP();
            otp.to = txb_Email.Text.Trim(); // Truyền email đích sang form OTP để gửi mail

            this.Hide(); // Ẩn form đăng ký tạm thời

            if (otp.ShowDialog() == DialogResult.OK) // Người dùng nhập chính xác OTP
            {
                if (RegisterAccount())
                {
                    MessageBox.Show("Đăng ký thành công! Vui lòng chờ Admin phê duyệt kích hoạt tài khoản.",
                        "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form đăng ký sau khi hoàn tất thành công
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu dữ liệu vào hệ thống.", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
            else
            {
                // Nếu hủy hoặc nhập OTP sai và đóng form OTP
                this.Show();
            }
        }
        // =========================================================
        // LỆNH LƯU TÀI KHOẢN VÀO CƠ SỞ DỮ LIỆU
        // =========================================================
        private bool RegisterAccount()
        {
            MY_DB my_db = new MY_DB();

            // Đổi tên cột từ 'role' sang 'Position' cho khớp với cấu trúc bảng login trong DB của bạn
            string queryLogin = "INSERT INTO login (id, username, password, role) VALUES (@id, @user, @pass, @pos)";
            SqlCommand cmdLogin = new SqlCommand(queryLogin, my_db.conn);

            cmdLogin.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(txb_MSGV.Text.Trim());
            cmdLogin.Parameters.Add("@user", SqlDbType.VarChar).Value = txb_User.Text.Trim();
            cmdLogin.Parameters.Add("@pass", SqlDbType.VarChar).Value = ComputeSHA256(txb_Pass.Text);

            // Gán giá trị chuỗi quyền dựa trên vị trí position (1 = Student, 2 = HR)
            cmdLogin.Parameters.Add("@pos", SqlDbType.VarChar).Value = (position == 2) ? "HR" : "Student";

            // Đoạn xử lý lưu thông tin chi tiết vào bảng phụ (Student hoặc HR)
            string queryDetail = "";
            if (position == 2) // Nếu là HR
            {
                queryDetail = "INSERT INTO HR (Id, Username, Fname, Lname, Email, Picture) VALUES (@id, @user, @fname, @lname, @email, @pic)";
            }
            else // Nếu là Student
            {
                queryDetail = "INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Addr, Htown, Email, Pic) VALUES (@id, @fname, @lname, @dob, @gder, @phone, @addr, @htown, @email, @pic)";
            }

            SqlCommand cmdDetail = new SqlCommand(queryDetail, my_db.conn);

            // Khởi tạo các tham số chung cho bảng chi tiết
            cmdDetail.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(txb_MSGV.Text.Trim());
            cmdDetail.Parameters.Add("@fname", SqlDbType.NVarChar).Value = txb_Fname.Text.Trim();
            cmdDetail.Parameters.Add("@lname", SqlDbType.NVarChar).Value = txb_Lname.Text.Trim();
            cmdDetail.Parameters.Add("@email", SqlDbType.VarChar).Value = txb_Email.Text.Trim();

            if (position == 2)
            {
                cmdDetail.Parameters.Add("@user", SqlDbType.VarChar).Value = txb_User.Text.Trim();
            }
            else
            {
                // Các tham số đặc thù riêng của bảng Student (bạn bổ sung thêm nếu form có ô nhập)
                cmdDetail.Parameters.Add("@dob", SqlDbType.DateTime).Value = DateTime.Now; // Hoặc dtp_Dob.Value
                cmdDetail.Parameters.Add("@gder", SqlDbType.NVarChar).Value = "Nam";       // Hoặc cbo_Gender.Text
                cmdDetail.Parameters.Add("@phone", SqlDbType.VarChar).Value = "";
                cmdDetail.Parameters.Add("@addr", SqlDbType.NVarChar).Value = "";
                cmdDetail.Parameters.Add("@htown", SqlDbType.NVarChar).Value = "";
            }

            // Chuyển đổi ảnh đại diện từ PictureBox sang mảng byte lưu vào DB
            MemoryStream ms = new MemoryStream();
            ptb_Picture.Image.Save(ms, ptb_Picture.Image.RawFormat);
            byte[] imgByte = ms.ToArray();
            cmdDetail.Parameters.Add("@pic", SqlDbType.Image).Value = imgByte;

            try
            {
                my_db.openConnection();

                // Sử dụng Transaction hoặc thực thi tuần tự cả 2 lệnh
                int resLogin = cmdLogin.ExecuteNonQuery();
                int resDetail = cmdDetail.ExecuteNonQuery();

                if (resLogin > 0 && resDetail > 0)
                {
                    return true; // Lưu thành công cả 2 bảng
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                           "SELECT Username FROM HR WHERE Username = @user" +
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
                           "SELECT Email FROM HR WHERE Email = @email" +
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
            if (string.IsNullOrWhiteSpace(txb_MSGV.Text) ||
                string.IsNullOrWhiteSpace(txb_Fname.Text) ||
                string.IsNullOrWhiteSpace(txb_Lname.Text) ||
                string.IsNullOrWhiteSpace(txb_User.Text) ||
                string.IsNullOrWhiteSpace(txb_Pass.Text) ||
                string.IsNullOrWhiteSpace(txb_Email.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các thông tin bắt buộc!", "Dữ liệu thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra MSGV/MSSV phải là số nguyên nhập vào hợp lệ
            if (!int.TryParse(txb_MSGV.Text.Trim(), out _))
            {
                MessageBox.Show("Mã số (ID) phải là một chuỗi ký tự số!", "Dữ liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra định dạng Email chuẩn bằng Regex thức tế
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txb_Email.Text.Trim(), emailPattern))
            {
                MessageBox.Show("Định dạng Email không đúng quy định! Vui lòng kiểm tra lại.", "Dữ liệu sai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

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
    }
}