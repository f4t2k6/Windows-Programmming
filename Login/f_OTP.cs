using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMonHoc
{
    //Bỏ lỗi CA1416
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class f_OTP : Form
    {
        // Thuộc tính nhận email đích từ f_Register truyền sang
        public string to { get; set; } = "";
        public string targetRole { get; set; } = "";
        public Action<string, string>? onVerifySuccess { get; set; }
        public Action? onBackToForget { get; set; }
        private string generatedOTP = "";
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

        private async void f_OTP_Load(object sender, EventArgs e)
        {
            // Định dạng hiển thị chuỗi thông báo email đích cụ thể (Đã áp dụng che giấu Email)
            if (!string.IsNullOrEmpty(to))
            {
                lbl_Info.Text = $"Mã xác thực đã được gửi đến email:\n{MaskEmail(to)}";
            }

            // Gửi bất đồng bộ -> không làm đơ UI khi mở form
            await GenerateAndSendOTPAsync();
        }

        // =========================================================
        // LOGIC SINH MÃ VÀ GỬI EMAIL QUA SMTP
        // =========================================================
        private async Task GenerateAndSendOTPAsync()
        {
            btn_Verify.Enabled = false;
            btn_Resend.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                Random rand = new Random();
                generatedOTP = rand.Next(100000, 999999).ToString();
                otpCreationTime = DateTime.Now;

                string fromEmail = "huyphat06112006@gmail.com";
                string appPassword = "rqer rsck gmnp aksu\r\n";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail, "HỆ THỐNG QUẢN LÝ SINH VIÊN");
                mail.To.Add(to);
                mail.Subject = "[Xác thực OTP] - Đăng ký tài khoản mới";
                mail.IsBodyHtml = true;
                mail.Body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Inter:wght@400;600;700&display=swap');
        body {{ font-family: 'Inter', sans-serif; background-color: #f3f4f6; margin: 0; padding: 0; }}
        .wrapper {{ width: 100%; background-color: #f3f4f6; padding: 50px 0; }}
        .container {{ max-width: 500px; margin: 0 auto; background-color: #ffffff; border-radius: 16px; overflow: hidden; box-shadow: 0 10px 25px rgba(0,0,0,0.05); }}
        .header {{ background: linear-gradient(135deg, #4f46e5 0%, #7c3aed 100%); padding: 35px 20px; text-align: center; }}
        .header h1 {{ color: #ffffff; margin: 0; font-size: 22px; font-weight: 700; letter-spacing: 1.5px; text-transform: uppercase; }}
        .content {{ padding: 40px 35px; text-align: center; }}
        .content p {{ color: #374151; font-size: 15px; line-height: 1.6; margin: 0 0 20px; text-align: left; }}
        .otp-container {{ margin: 35px 0; }}
        .otp-code {{ font-size: 40px; font-weight: 700; color: #1f2937; letter-spacing: 12px; padding: 20px 30px; background: #f9fafb; border-radius: 12px; display: inline-block; border: 1px solid #e5e7eb; box-shadow: inset 0 2px 4px rgba(0,0,0,0.02); }}
        .security-tip {{ background-color: #fffbeb; border-left: 4px solid #f59e0b; padding: 15px 20px; text-align: left; border-radius: 4px; margin-top: 30px; }}
        .security-tip p {{ margin: 0; color: #92400e; font-size: 13px; line-height: 1.5; }}
        .footer {{ background-color: #f9fafb; padding: 25px 20px; text-align: center; border-top: 1px solid #e5e7eb; }}
        .footer p {{ margin: 0; font-size: 12px; color: #6b7280; line-height: 1.6; }}
    </style>
</head>
<body>
    <div class='wrapper'>
        <div class='container'>
            <div class='header'>
                <h1>Hệ Thống Quản Lý</h1>
            </div>
            <div class='content'>
                <p>Xin chào,</p>
                <p>Chúng tôi nhận được yêu cầu xác thực email cho tài khoản của bạn. Vui lòng sử dụng mã bảo mật dưới đây để hoàn tất quá trình này:</p>
                
                <div class='otp-container'>
                    <div class='otp-code'>{generatedOTP}</div>
                </div>
                
                <p>Mã xác thực này có hiệu lực trong vòng <strong>5 phút</strong>.</p>
                
                <div class='security-tip'>
                    <strong>⚠️ Cảnh báo bảo mật:</strong>
                    <p>Tuyệt đối không chia sẻ mã này với bất kỳ ai. Nhân viên hỗ trợ sẽ không bao giờ yêu cầu bạn cung cấp mã OTP.</p>
                </div>
            </div>
            <div class='footer'>
                <p>Email này được gửi tự động, vui lòng không trả lời.</p>
                <p>&copy; {DateTime.Now.Year} Bản quyền thuộc về Hệ Thống Quản Lý. All rights reserved.</p>
            </div>
        </div>
    </div>
</body>
</html>";

                using SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
                smtp.EnableSsl = true;

                // Điểm mấu chốt: SendMailAsync KHÔNG block UI thread
                await smtp.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể gửi mã OTP qua email!\nChi tiết lỗi: " + ex.Message,
                    "Lỗi Gửi Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btn_Verify.Enabled = true;
                btn_Resend.Enabled = true;
            }
        }

        // =========================================================
        // SỰ KIỆN NÚT XÁC NHẬN MÃ OTP (CHIỀU THUẬN)
        // =========================================================
        private void btn_Verify_Click(object sender, EventArgs e)
        {
            string inputOTP = txb_OTP.Text.Trim();

            if (string.IsNullOrEmpty(inputOTP))
            {
                MessageBox.Show("Vui lòng nhập mã OTP gồm 6 chữ số!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra OTP còn hiệu lực không (5 phút)
            TimeSpan diff = DateTime.Now - otpCreationTime;
            if (diff.TotalMinutes > 5)
            {
                MessageBox.Show("Mã OTP của bạn đã hết hạn (quá 5 phút)!\nVui lòng nhấn 'Gửi lại mã OTP' để nhận mã mới.",
                                "Hết Hạn Xác Thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txb_OTP.Clear();
                return;
            }

            if (inputOTP == generatedOTP)
            {
                // ✅ Thông báo xác thực thành công cho người dùng biết
                MessageBox.Show("Xác thực email thành công!", "OTP Hợp Lệ",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ f_OTP LINH ĐỘNG giữa 2 luồng sử dụng:
                //    - Luồng ĐĂNG KÝ (f_Register): không gán onVerifySuccess
                //      -> set DialogResult.OK rồi Close(), f_Register tự xử lý qua FormClosed.
                //    - Luồng QUÊN MẬT KHẨU (f_ForgetPass): có gán onVerifySuccess
                //      -> gọi thẳng callback để nhảy sang f_ResetPass, không qua DialogResult/FormClosed,
                //         tránh bị f_ForgetPass.FormClosed hiểu nhầm là "Hủy" và quay lại chính nó.
                if (onVerifySuccess != null)
                {
                    onVerifySuccess.Invoke(to, targetRole);
                    this.Close();
                }
                else
                {
                    // ✅ Set DialogResult.OK → f_Register.FormClosed sẽ nhận được tín hiệu này
                    //    và tự xử lý lưu DB tuỳ theo role (Student → login, HR → register_HR)
                    this.DialogResult = DialogResult.OK;

                    // ✅ Đóng form OTP — kích hoạt sự kiện FormClosed bên f_Register
                    this.Close();
                }
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
        private async void btn_Resend_Click(object sender, EventArgs e)
        {
            await GenerateAndSendOTPAsync();
            MessageBox.Show("Một mã OTP mới đã được gửi lại vào email của bạn! Mã có hiệu lực trong 5 phút.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Chặn người dùng nhập chữ vào ô OTP (chỉ chấp nhận ký tự số và phím điều khiển)
        private void txb_OTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // =========================================================
        // SỰ KIỆN NÚT HỦY MÃ OTP (CHIỀU NGHỊCH)
        // =========================================================
        private void btn_Cancel_OTP_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Không phải OK → f_Register sẽ redirect về login
            this.Close();
        }

        private void lbl_Title_Click(object sender, EventArgs e)
        {

        }
    }
}