using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectMonHoc.Classes
{
    public class AILoginAnalyzer
    {
        private readonly string _apiKey;
        private readonly string _modelName;
        private static readonly HttpClient client = new HttpClient();

        public AILoginAnalyzer()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = "API.config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            _apiKey = config.AppSettings.Settings["GroqApiKey"]?.Value ?? "";
            _modelName = config.AppSettings.Settings["GroqModel"]?.Value ?? "llama-3.3-70b-versatile";
        }

        public class AIResult
        {
            public bool IsAbnormal { get; set; }
            public string Reason { get; set; } = "";
        }

        public async Task<AIResult> AnalyzeLoginBehaviorAsync(string username, List<string> recentLogs)
        {
            if (string.IsNullOrEmpty(_apiKey) || _apiKey.Contains("your_api_key"))
            {
                return new AIResult { IsAbnormal = false, Reason = "Missing API Key" };
            }

            string logStr = string.Join("\n", recentLogs);
            
            string systemPrompt = @"Bạn là một chuyên gia an ninh mạng. Dưới đây là nhật ký đăng nhập gần đây. 
Hãy phân tích xem có dấu hiệu của tấn công Brute-force hoặc hành vi bất thường (đăng nhập vào giờ quá khuya 1AM-5AM, sai nhiều lần liên tục) hay không. 
Chỉ trả lời duy nhất một chuỗi JSON hợp lệ với định dạng: { ""IsAbnormal"": true/false, ""Reason"": ""Lý do ngắn gọn tiếng Việt"" }";

            string userPrompt = $"User: {username}\nLogs:\n{logStr}";

            var requestBody = new
            {
                model = _modelName,
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = userPrompt }
                },
                temperature = 0.2,
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
                                bool isAbnormal = innerDoc.RootElement.GetProperty("IsAbnormal").GetBoolean();
                                string reason = innerDoc.RootElement.GetProperty("Reason").GetString() ?? "";
                                
                                return new AIResult { IsAbnormal = isAbnormal, Reason = reason };
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
                Console.WriteLine("Exception in AI Analyze: " + ex.Message);
            }

            return new AIResult { IsAbnormal = false, Reason = "API Call Failed" };
        }
    }
}
