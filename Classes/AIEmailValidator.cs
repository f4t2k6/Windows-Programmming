using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectMonHoc.Classes
{
    public class AIEmailValidator
    {
        private readonly string _apiKey;
        private readonly string _modelName;
        private static readonly HttpClient client = new HttpClient();

        public AIEmailValidator()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = "API.config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            _apiKey = config.AppSettings.Settings["GroqApiKey"]?.Value ?? "";
            _modelName = config.AppSettings.Settings["GroqModel"]?.Value ?? "llama-3.3-70b-versatile";
        }

        public class AIValidationResult
        {
            public bool IsDisposable { get; set; }
            public string Reason { get; set; } = "";
        }

        public async Task<AIValidationResult> CheckEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(_apiKey) || _apiKey.Contains("your_api_key"))
            {
                // Nếu chưa cấu hình API, cứ cho qua mặc định
                return new AIValidationResult { IsDisposable = false, Reason = "Missing API Key" };
            }

            string systemPrompt = @"Bạn là hệ thống kiểm duyệt đăng ký người dùng.
Nhiệm vụ của bạn là đánh giá xem địa chỉ email được cung cấp có phải là email tạm thời (disposable/temporary email), email rác hoặc email sinh ngẫu nhiên dùng một lần (như mailinator, 10minutemail, yopmail, temp-mail, guerrilla mail...) hay không.
Chỉ trả lời một chuỗi JSON hợp lệ duy nhất với định dạng: { ""IsDisposable"": true/false, ""Reason"": ""Lý do ngắn gọn tiếng Việt"" }";

            string userPrompt = $"Email cần kiểm tra: {email}";

            var requestBody = new
            {
                model = _modelName,
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userPrompt }
                },
                temperature = 0.1,
                response_format = new { type = "json_object" }
            };

            string jsonBody = JsonSerializer.Serialize(requestBody);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.groq.com/openai/v1/chat/completions")
            {
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    
                    using (JsonDocument doc = JsonDocument.Parse(responseContent))
                    {
                        var choices = doc.RootElement.GetProperty("choices");
                        if (choices.GetArrayLength() > 0)
                        {
                            var content = choices[0].GetProperty("message").GetProperty("content").GetString() ?? "";
                            
                            // Parse inner JSON
                            using (JsonDocument innerDoc = JsonDocument.Parse(content))
                            {
                                bool isDisposable = innerDoc.RootElement.GetProperty("IsDisposable").GetBoolean();
                                string reason = innerDoc.RootElement.GetProperty("Reason").GetString() ?? "";
                                
                                return new AIValidationResult { IsDisposable = isDisposable, Reason = reason };
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("API Error: " + await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in AI Email Validator: " + ex.Message);
            }

            // Mặc định không chặn nếu API lỗi
            return new AIValidationResult { IsDisposable = false, Reason = "API Call Failed" };
        }
    }
}
