using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectMonHoc.Child_Forms
{
    public partial class f_createTB_DB : Form
    {
        // =============================================
        // ĐỌC API.config bằng XLinq — không cần NuGet package
        // API.config nằm cùng thư mục với file .exe
        // =============================================
        private static string ReadApiConfig(string key)
        {
            try
            {
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "API.config");
                XDocument doc = XDocument.Load(configPath);
                foreach (XElement add in doc.Descendants("add"))
                {
                    if (add.Attribute("key")?.Value == key)
                        return add.Attribute("value")?.Value?.Trim() ?? "";
                }
                return "";
            }
            catch
            {
                return "";
            }
        }

        // Đọc API Key từ API.config tại thời điểm gọi (tránh cache cứng)
        private string GroqApiKey => ReadApiConfig("GroqApiKey");

        // Tên model AI từ API.config — đổi model chỉ cần sửa file, không cần build lại
        private string GroqModel
        {
            get
            {
                string model = ReadApiConfig("GroqModel");
                return string.IsNullOrWhiteSpace(model) ? "llama-3.3-70b-versatile" : model;
            }
        }

        public f_createTB_DB()
        {
            InitializeComponent();

            // Khi flp_ChatHistory thay đổi kích thước (form Dock=Fill mở rộng),
            // cập nhật lại Width của tất cả UC con để chúng điền đúng chiều ngang.
            flp_ChatHistory.SizeChanged += (s, e) => SyncUCWidths();
        }

        /// <summary>
        /// Đặt Width của tất cả uc_SQLBuilder_mainform con = chiều rộng khả dụng của flp.
        /// Trừ đi padding trái + phải (20) và độ rộng thanh cuộn dọc (20).
        /// </summary>
        private void SyncUCWidths()
        {
            int targetWidth = flp_ChatHistory.ClientSize.Width
                            - flp_ChatHistory.Padding.Left
                            - flp_ChatHistory.Padding.Right
                            - SystemInformation.VerticalScrollBarWidth;
            if (targetWidth < 100) return;

            foreach (Control c in flp_ChatHistory.Controls)
            {
                if (c is User_control.uc_SQLBuilder_mainform uc)
                    uc.Width = targetWidth;
            }
        }


        // Hàm gọi API bất đồng bộ giúp mượt giao diện, không đơ App
        private async Task<string> GenerateSqlFromAI(string userPrompt)
        {
            // Kiểm tra an toàn xem đã điền API Key hợp lệ chưa
            if (string.IsNullOrEmpty(GroqApiKey) || GroqApiKey.StartsWith("gsk_điền_key"))
            {
                return "LỖI: Ứng dụng chưa đọc được API Key hợp lệ từ file API.config! Hãy điền key thật vào thẻ <appSettings>.";
            }

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {GroqApiKey}");

            // Cả API Key lẫn tên model đều lấy từ API.config
            var requestBody = new
            {
                model = GroqModel,
                messages = new[]
                {
                    new { role = "system", content = "Bạn là chuyên gia SQL Server. Sinh duy nhất mã SQL thô bắt đầu bằng CREATE TABLE. Không giải thích, không bọc trong ```sql." },
                    new { role = "user", content = userPrompt }
                },
                temperature = 0.1,
                stream = false
            };

            string jsonBody = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                Uri groqUri = new Uri("https://api.groq.com/openai/v1/chat/completions");
                HttpResponseMessage response = await client.PostAsync(groqUri, content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    return "LỖI_API: " + response.StatusCode + " - " + errorContent;
                }

                string resultJson = await response.Content.ReadAsStringAsync();

                using JsonDocument doc = JsonDocument.Parse(resultJson);
                if (doc.RootElement.TryGetProperty("choices", out JsonElement choices) &&
                    choices.GetArrayLength() > 0)
                {
                    string sqlCode = choices[0]
                        .GetProperty("message")
                        .GetProperty("content")
                        .GetString() ?? "";
                    return sqlCode.Trim();
                }

                return "LỖI: Không tìm thấy cấu trúc choices trong JSON trả về.";
            }
            catch (Exception ex)
            {
                return "LỖI_MẠNG: " + ex.Message;
            }
        }

        private async void btn_Send_Click(object sender, EventArgs e)
        {
            string prompt = txt_Prompt.Text.Trim();
            if (string.IsNullOrEmpty(prompt)) return;

            // Khóa nút để tránh spam click khi đang đợi kết quả
            btn_Send.Enabled = false;
            btn_Send.Text = "Đang quét dữ liệu...";

            // Gọi AI xử lý ngôn ngữ tự nhiên thành SQL
            string generatedSql = await GenerateSqlFromAI(prompt);

            // Khởi tạo thẻ chat động từ User_Control
            User_control.uc_SQLBuilder_mainform newChatBubble = new User_control.uc_SQLBuilder_mainform();

            if (generatedSql.StartsWith("LỖI"))
            {
                newChatBubble.SetData(prompt, "Hệ thống không thể sinh mã: " + generatedSql);
                newChatBubble.DisableRunButton(); // Lỗi thì khóa nút tạo bảng
            }
            else
            {
                newChatBubble.SetData(prompt, generatedSql); // Đổ dữ liệu chuẩn vào thẻ chat
            }

            // Đẩy thẻ chat vào FlowLayoutPanel và tự động cuộn xuống dưới cùng
            // Đặt Width đúng ngay lập tức trước khi Add để tránh layout sai
            SyncUCWidths();   // cập nhật UC cũ (nếu có)
            int ucWidth = flp_ChatHistory.ClientSize.Width
                        - flp_ChatHistory.Padding.Left
                        - flp_ChatHistory.Padding.Right
                        - SystemInformation.VerticalScrollBarWidth;
            if (ucWidth > 100) newChatBubble.Width = ucWidth;

            flp_ChatHistory.Controls.Add(newChatBubble);
            flp_ChatHistory.ScrollControlIntoView(newChatBubble);

            // Giải phóng lại ô nhập liệu cho lượt hỏi tiếp theo
            txt_Prompt.Text = "";
            btn_Send.Enabled = true;
            btn_Send.Text = "Gửi Yêu Cầu";
        }
    }
}