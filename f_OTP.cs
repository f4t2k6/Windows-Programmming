using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_OTP : Form
    {
        // Thuộc tính nhận email đích từ f_Register truyền sang
        public string to { get; set; } = "";

        // Biến cục bộ lưu trữ mã định danh OTP được sinh ra ngẫu nhiên
        private string generatedOTP = "";

        // [NÂNG CAO] Biến lưu trữ thời gian tạo mã OTP để kiểm tra hết hạn
        private DateTime otpCreationTime;

        public f_OTP()
        {
            InitializeComponent();
        }

        // [NÂNG CAO] Hàm che giấu phần tên của email bằng dấu *
        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@")) return email;

            string[] parts = email.Split('@');
            // Nếu tên email quá ngắn (<= 2 ký tự) thì giữ nguyên để tránh lỗi
            if (parts[0].Length <= 2) return email;

            string namePart = parts[0];
            // Lấy 2 ký tự đầu, phần còn lại thay bằng chuỗi dấu *
            string maskedName = namePart.Substring(0, 2) + new string('*', namePart.Length - 2);

            return maskedName + "@" + parts[1];
        }

        private void f_OTP_Load(object sender, EventArgs e)
        {
            // Định dạng hiển thị chuỗi thông báo email đích cụ thể (Đã áp dụng che giấu Email)
            if (!string.IsNullOrEmpty(to))
            {
                lbl_Info.Text = $"Mã xác thực đã được gửi đến email:\n{MaskEmail(to)}";
            }

            // Tự động sinh mã và gửi email ngay khi form được mở lên
            GenerateAndSendOTP();
        }

        // =========================================================
        // LOGIC SINH MÃ VÀ GỬI EMAIL QUA SMTP
        // =========================================================
        private void GenerateAndSendOTP()
        {
            try
            {
                // 1. Sinh ngẫu nhiên số có 6 chữ số từ 100000 đến 999999
                Random rand = new Random();
                generatedOTP = rand.Next(100000, 999999).ToString();

                // [NÂNG CAO] Lưu lại thời gian bắt đầu sinh mã OTP
                otpCreationTime = DateTime.Now;

                // 2. Cấu hình nội dung thư điện tử gửi đi
                string fromEmail = "huyphat06112006@gmail.com"; // Thay bằng Email Admin của bạn
                string appPassword = "rqer rsck gmnp aksu\r\n"; // Thay bằng Mật khẩu ứng dụng (App Password)

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail, "HỆ THỐNG QUẢN LÝ SINH VIÊN");
                mail.To.Add(to);
                mail.Subject = "[Xác thực OTP] - Đăng ký tài khoản mới";
                mail.Body = $"Chào bạn,\n\nMã OTP xác thực đăng ký tài khoản của bạn là: {generatedOTP}\n" +
                            "Mã này có hiệu lực trong vòng 5 phút. Vui lòng không chia sẻ mã này cho bất kỳ ai.\n\n" +
                            "Trân trọng,\nBan Quản Trị Hệ Thống.";

                // 3. Cấu hình Client SMTP kết nối Server (Ví dụ cấu hình của Gmail)
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
                smtp.EnableSsl = true;

                // Tiến hành gửi ngầm tránh làm đơ giao diện
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể gửi mã OTP qua email!\nChi tiết lỗi: " + ex.Message,
                    "Lỗi Gửi Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SỰ KIỆN NÚT XÁC NHẬN MÃ OTP
        // =========================================================
        private void btn_Verify_Click(object sender, EventArgs e)
        {
            string inputOTP = txb_OTP.Text.Trim();

            if (string.IsNullOrEmpty(inputOTP))
            {
                MessageBox.Show("Vui lòng nhập mã OTP gồm 6 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [NÂNG CAO] Kiểm tra thời gian hết hạn (5 phút = 300 giây)
            TimeSpan diff = DateTime.Now - otpCreationTime;
            if (diff.TotalMinutes > 5)
            {
                MessageBox.Show("Mã OTP của bạn đã hết hạn (quá 5 phút)!\nVui lòng nhấn 'Gửi lại mã OTP' để nhận mã mới.",
                                "Hết Hạn Xác Thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txb_OTP.Clear();
                return; // Dừng xử lý
            }

            // Kiểm tra tính chính xác của mã nhập vào so với mã hệ thống sinh ra
            if (inputOTP == generatedOTP)
            {
                // Trả về kết quả OK để báo cho f_Register biết là đã xác thực hợp lệ
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã OTP bạn nhập không chính xác! Vui lòng kiểm tra lại.",
                    "Xác Thực Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_OTP.Clear();
                txb_OTP.Focus();
            }
        }

        // =========================================================
        // SỰ KIỆN NÚT GỬI LẠI MÃ (RESEND)
        // =========================================================
        private void btn_Resend_Click(object sender, EventArgs e)
        {
            btn_Resend.Enabled = false;
            Cursor = Cursors.WaitCursor;

            // Gọi lại hàm này sẽ tự động reset mã mới và thời gian (otpCreationTime) mới
            GenerateAndSendOTP();

            Cursor = Cursors.Default;
            btn_Resend.Enabled = true;
            MessageBox.Show("Một mã OTP mới đã được gửi lại vào email của bạn! Mã có hiệu lực trong 5 phút.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Chặn người dùng nhập chữ vào ô OTP (chỉ chấp nhận ký tự số và phím điều khiển)
        private void txb_OTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Cancel_OTP_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}