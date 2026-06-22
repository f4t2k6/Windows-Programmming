using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjectMonHoc.Classes
{
    public class EmailService
    {
        private readonly string _smtpEmail;
        private readonly string _smtpPassword;

        public EmailService()
        {
            // Fallback for tests if not in App.config
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = "API.config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            _smtpEmail = config.AppSettings.Settings["SmtpEmail"]?.Value ?? "";
            _smtpPassword = config.AppSettings.Settings["SmtpPassword"]?.Value ?? "";
        }

        public async Task SendWarningEmailAsync(string toEmail, string subject, string body)
        {
            if (string.IsNullOrEmpty(_smtpEmail) || string.IsNullOrEmpty(_smtpPassword) || _smtpEmail.Contains("your_email"))
            {
                Console.WriteLine("SMTP chưa được cấu hình. Bỏ qua gửi email.");
                return;
            }

            try
            {
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_smtpEmail, _smtpPassword);

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_smtpEmail, "Hệ thống Cảnh báo An ninh"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };
                    
                    mailMessage.To.Add(toEmail);

                    await client.SendMailAsync(mailMessage);
                    Console.WriteLine("Email cảnh báo đã được gửi thành công đến " + toEmail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi gửi email: " + ex.Message);
            }
        }
    }
}
