using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Configuration;

namespace ProjectMonHoc.Child_Forms
{
    public partial class f_createTB_DB : Form
    {
        // ĐÃ SỬA: Loại bỏ readonly cứng, chuyển thành một Property động 
        // để luôn đọc chính xác dữ liệu từ file App.config tại thời điểm bấm nút
        private string GroqApiKey
        {
            get
            {
                string key = ConfigurationManager.AppSettings["GroqApiKey"];
                return string.IsNullOrEmpty(key) ? "" : key.Trim();
            }
        }

        public f_createTB_DB()
        {
            InitializeComponent();
        }

        // Hàm gọi API bất đồng bộ giúp mượt giao diện, không đơ App
        private async Task<string> GenerateSqlFromAI(string userPrompt)
        {
            // Kiểm tra an toàn xem code đã thực sự chạm được vào file App.config chưa
            if (string.IsNullOrEmpty(GroqApiKey) || GroqApiKey.StartsWith("gsk_điền_key"))
            {
                return "LỖI: Ứng dụng chưa đọc được API Key hợp lệ từ file App.config! Hãy rà soát lại thẻ <appSettings>.";
            }

            using (HttpClient client = new HttpClient())
            {
                // ĐÃ SỬA: Sử dụng trực tiếp Property động đã được dọn sạch khoảng trắng
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {GroqApiKey}");

                // Cấu trúc lại RequestBody bằng Object tường minh
                var requestBody = new
                {
                    model = "openai/gpt-oss-120b",
                    messages = new[]
                    {
                        new { role = "system", content = "Bạn là chuyên gia SQL Server. Sinh duy nhất mã SQL thô bắt đầu bằng CREATE TABLE. Không giải thích, không bọc trong ```sql." },
                        new { role = "user", content = userPrompt }
                    },
                    temperature = 0.1,
                    stream = false
                };

                string jsonBody = JsonConvert.SerializeObject(requestBody);
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

                    var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(resultJson);

                    if (result != null && result.ContainsKey("choices"))
                    {
                        dynamic choices = result["choices"];
                        string sqlCode = choices[0].message.content;
                        return sqlCode.Trim();
                    }

                    return "LỖI: Không tìm thấy cấu trúc choices trong JSON trả về.";
                }
                catch (Exception ex)
                {
                    return "LỖI_MẠNG: " + ex.Message;
                }
            }
        }

        private async void btn_Send_Click(object sender, EventArgs e)
        {
            string prompt = txt_Prompt.Text.Trim();
            if (string.IsNullOrEmpty(prompt)) return;

            // Khóa nút để tránh người dùng spam click khi đang đợi kết quả
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

            // Đẩy thẻ chat vào FlowLayoutPanel và tự động cuộn khung nhìn xuống dưới cùng
            flp_ChatHistory.Controls.Add(newChatBubble);
            flp_ChatHistory.ScrollControlIntoView(newChatBubble);

            // Giải phóng lại ô nhập liệu cho lượt hỏi tiếp theo
            txt_Prompt.Text = "";
            btn_Send.Enabled = true;
            btn_Send.Text = "Gửi Yêu Cầu";
        }
    }
}