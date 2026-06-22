using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectMonHoc.Classes
{
    public class ChatMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

    public class NavigationResult
    {
        public string Intent { get; set; }
        public string Message { get; set; }
    }

    public class VoiceInputResult
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string MSSV { get; set; }
        // Debug fields - không được serialize bởi JSON từ AI
        [System.Text.Json.Serialization.JsonIgnore]
        public string RawText { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string ErrorMessage { get; set; }
    }

    public class ChatbotService
    {
        private readonly string apiKey;
        private readonly string modelName;
        private readonly HttpClient httpClient;
        private readonly List<ChatMessage> conversationHistory;

        public ChatbotService()
        {
            // Đọc API.config
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\API.config");
            if (!File.Exists(configPath))
            {
                // Thử đường dẫn khác nếu đang chạy build thật
                configPath = "API.config";
            }

            if (File.Exists(configPath))
            {
                XDocument doc = XDocument.Load(configPath);
                foreach (var el in doc.Descendants("add"))
                {
                    string key = el.Attribute("key")?.Value;
                    string val = el.Attribute("value")?.Value;
                    if (key == "GroqApiKey") apiKey = val;
                    if (key == "GroqModel") modelName = val;
                }
            }

            // Nếu không tìm thấy, gán giá trị mặc định (phòng hờ)
            if (string.IsNullOrEmpty(apiKey))
                apiKey = "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";
            if (string.IsNullOrEmpty(modelName))
                modelName = "llama-3.3-70b-versatile";

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            conversationHistory = new List<ChatMessage>();
            
            // Mặc định là prompt quên mật khẩu
            SetSystemPrompt(@"Bạn là trợ lý ảo AI siêu thân thiện và nhiệt tình của phần mềm Hệ Thống Quản Lý Sinh Viên.
Nhiệm vụ của bạn là hướng dẫn người dùng quy trình khôi phục mật khẩu.
Hãy nói ngắn gọn, dễ hiểu và chuyên nghiệp.

Quy trình chuẩn cần hướng dẫn:
1. Nhập Email của họ vào ô 'Email'.
2. Bấm nút 'Nhận Mã OTP'.
3. Mở Gmail để lấy mã số gồm 6 chữ số.
4. Nhập mã OTP vào phần mềm để xác thực.
5. Tạo mật khẩu mới và xác nhận.

Nếu người dùng hỏi về đăng nhập, nhắc họ rằng lúc đăng nhập sẽ cần dùng app Google Authenticator (Mã 2FA) trên điện thoại.");
        }

        public void SetSystemPrompt(string prompt)
        {
            conversationHistory.Clear();
            conversationHistory.Add(new ChatMessage { Role = "system", Content = prompt });
        }

        public async Task<string> SendMessageAsync(string userMessage)
        {
            conversationHistory.Add(new ChatMessage { Role = "user", Content = userMessage });

            var requestBody = new
            {
                model = modelName,
                messages = conversationHistory,
                temperature = 0.5,
                max_tokens = 500
            };

            string jsonBody = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);
                
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(responseJson))
                    {
                        var root = doc.RootElement;
                        var choices = root.GetProperty("choices");
                        var message = choices[0].GetProperty("message");
                        string replyContent = message.GetProperty("content").GetString();

                        conversationHistory.Add(new ChatMessage { Role = "assistant", Content = replyContent });
                        return replyContent;
                    }
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    return "Xin lỗi, tôi đang gặp lỗi kết nối với máy chủ AI: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối: " + ex.Message;
            }
        }

        public async Task<NavigationResult> SendNavigationMessageAsync(string userMessage)
        {
            conversationHistory.Add(new ChatMessage { Role = "user", Content = userMessage });

            var requestBody = new
            {
                model = modelName,
                messages = conversationHistory,
                temperature = 0.1,
                max_tokens = 500,
                response_format = new { type = "json_object" }
            };

            string jsonBody = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);
                
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(responseJson))
                    {
                        var root = doc.RootElement;
                        var choices = root.GetProperty("choices");
                        var message = choices[0].GetProperty("message");
                        string replyContent = message.GetProperty("content").GetString();

                        conversationHistory.Add(new ChatMessage { Role = "assistant", Content = replyContent });
                        
                        // Parse the JSON intent
                        var result = JsonSerializer.Deserialize<NavigationResult>(replyContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        return result ?? new NavigationResult { Intent = "UNKNOWN", Message = "Xin lỗi, tôi không hiểu bạn muốn đi đâu." };
                    }
                }
                else
                {
                    return new NavigationResult { Intent = "ERROR", Message = "Xin lỗi, lỗi kết nối với máy chủ AI." };
                }
            }
            catch (Exception ex)
            {
                return new NavigationResult { Intent = "ERROR", Message = "Lỗi kết nối: " + ex.Message };
            }
        }

        public async Task<string> GetSmartAlertAsync(string statsContext)
        {
            var messages = new List<ChatMessage>
            {
                new ChatMessage { Role = "system", Content = "Bạn là trợ lý AI chuyên phân tích số liệu sinh viên. Hãy đưa ra 1 câu nhận xét hoặc cảnh báo thông minh ngắn gọn (khoảng 15-25 chữ) cho Quản lý. Nếu có nhiều sinh viên yếu/kém, hãy ưu tiên cảnh báo. Dùng giọng điệu chuyên nghiệp, cung cấp giá trị thông tin ngay lập tức. Đừng lặp lại toàn bộ số liệu." },
                new ChatMessage { Role = "user", Content = $"Dữ liệu thống kê hiện tại: {statsContext}" }
            };

            var requestBody = new
            {
                model = modelName,
                messages = messages,
                temperature = 0.5,
                max_tokens = 200
            };

            string jsonBody = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(responseJson))
                    {
                        var root = doc.RootElement;
                        var choices = root.GetProperty("choices");
                        var message = choices[0].GetProperty("message");
                        string replyContent = message.GetProperty("content").GetString();

                        // Loại bỏ dấu ngoặc kép bọc ngoài nếu AI vô tình thêm vào
                        replyContent = replyContent.Trim('"', ' ', '\n', '\r');
                        return "💡 AI Phân tích: " + replyContent;
                    }
                }
                else
                {
                    return "💡 AI Phân tích: Không thể kết nối tới máy chủ AI.";
                }
            }
            catch
            {
                return "💡 AI Phân tích: Đang gặp sự cố mạng.";
            }
        }

        public async Task<VoiceInputResult> ParseVoiceInputAsync(string voiceText)
        {
            var messages = new List<ChatMessage>
            {
                new ChatMessage { Role = "system", Content = "Bạn là trợ lý AI trích xuất dữ liệu sinh viên. Dữ liệu đầu vào là 1 câu văn giọng nói. Nhiệm vụ: trích xuất Fname (Họ và tên đệm), Lname (Tên chính cuối cùng), và MSSV (chỉ gồm các chữ số). Trả về JSON với 3 trường trên. Ví dụ: 'Thêm sinh viên Nguyễn Văn A MSSV 22110001' -> {\"Fname\": \"Nguyễn Văn\", \"Lname\": \"A\", \"MSSV\": \"22110001\"}. Trả về đối tượng JSON rỗng nếu không tìm thấy." },
                new ChatMessage { Role = "user", Content = voiceText }
            };

            var requestBody = new
            {
                model = modelName,
                messages = messages,
                temperature = 0.1,
                max_tokens = 200,
                response_format = new { type = "json_object" }
            };

            string jsonBody = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(responseJson))
                    {
                        var root = doc.RootElement;
                        var choices = root.GetProperty("choices");
                        var message = choices[0].GetProperty("message");
                        string replyContent = message.GetProperty("content").GetString();

                        var result = JsonSerializer.Deserialize<VoiceInputResult>(replyContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        return result ?? new VoiceInputResult();
                    }
                }
                return new VoiceInputResult();
            }
            catch
            {
                return new VoiceInputResult();
            }
        }

        /// <summary>
        /// Gửi file WAV lên Groq Whisper API để chuyển giọng nói tiếng Việt thành văn bản.
        /// </summary>
        /// <param name="wavBytes">Dữ liệu WAV ghi từ microphone</param>
        /// <returns>Văn bản tiếng Việt được nhận diện, hoặc null nếu lỗi</returns>
        public async Task<(string Text, string Error)> TranscribeAudioAsync(byte[] wavBytes)
        {
            try
            {
                using var formData = new MultipartFormDataContent();

                // Đính kèm file WAV
                var fileContent = new ByteArrayContent(wavBytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");
                formData.Add(fileContent, "file", "audio.wav");

                // Model Whisper của Groq - hỗ trợ tiếng Việt
                formData.Add(new StringContent("whisper-large-v3"), "model");
                formData.Add(new StringContent("vi"), "language"); // Chỉ định tiếng Việt
                formData.Add(new StringContent("transcribe"), "task");

                var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/audio/transcriptions", formData);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    using var doc = JsonDocument.Parse(responseBody);
                    string text = doc.RootElement.GetProperty("text").GetString()?.Trim() ?? "";
                    return (text, null);
                }
                else
                {
                    return (null, $"Whisper HTTP {(int)response.StatusCode}: {responseBody[..Math.Min(120, responseBody.Length)]}");
                }
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<string> SuggestCourseAsync(int mssv, string tenSV)
        {
            try
            {
                // 1. Lấy danh sách điểm các môn đã học
                string pastScores = "";
                string availableCourses = "";

                MY_DB db = new MY_DB();
                db.openConnection();

                string qScore = @"
                    SELECT course_name, DiemTK 
                    FROM Score 
                    WHERE student_id = @mssv AND DiemTK >= 5";
                var cmd1 = new Microsoft.Data.SqlClient.SqlCommand(qScore, db.conn);
                cmd1.Parameters.AddWithValue("@mssv", mssv);
                using (var r = cmd1.ExecuteReader())
                {
                    while (r.Read())
                    {
                        pastScores += $"- {r.GetString(0)}: {r.GetDouble(1)} điểm\n";
                    }
                }

                if (string.IsNullOrEmpty(pastScores)) pastScores = "(Chưa có dữ liệu điểm hoặc chưa qua môn nào)";

                // 2. Lấy danh sách môn học có thể đăng ký (Chưa đăng ký và chưa học qua)
                string qAvail = @"
                    SELECT c.MaMH, c.TenMH, c.SoTC 
                    FROM Course c 
                    WHERE c.MaMH NOT IN (SELECT MaMH FROM DKMH WHERE MSSV = @mssv)
                      AND c.MaMH NOT IN (SELECT course_id FROM Score WHERE student_id = @mssv AND DiemTK >= 5)";
                var cmd2 = new Microsoft.Data.SqlClient.SqlCommand(qAvail, db.conn);
                cmd2.Parameters.AddWithValue("@mssv", mssv);
                using (var r = cmd2.ExecuteReader())
                {
                    while (r.Read())
                    {
                        availableCourses += $"- [{r.GetString(0)}] {r.GetString(1)} ({r.GetInt32(2)} TC)\n";
                    }
                }
                db.closeConnection();

                if (string.IsNullOrEmpty(availableCourses)) return "Sinh viên đã hoàn thành hoặc đăng ký tất cả các môn.";

                // 3. Gửi cho AI
                var prompt = $@"
Bạn là cố vấn học tập AI. 
Sinh viên {tenSV} (MSSV: {mssv}) có bảng điểm các môn đã qua như sau:
{pastScores}

Các môn học hệ thống đang mở và sinh viên chưa học:
{availableCourses}

Dựa vào điểm số (thế mạnh môn học), hãy gợi ý 1 hoặc 2 môn học phù hợp nhất để sinh viên đăng ký học tiếp theo. 
Trả lời ngắn gọn, thân thiện và giải thích lý do ngắn gọn vì sao chọn môn đó.";

                var messages = new List<ChatMessage>
                {
                    new ChatMessage { Role = "system", Content = "Bạn là cố vấn học tập AI." },
                    new ChatMessage { Role = "user", Content = prompt }
                };

                var requestBody = new
                {
                    model = modelName,
                    messages = messages,
                    temperature = 0.5,
                    max_tokens = 300
                };

                string jsonBody = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(responseJson);
                    return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString()?.Trim();
                }
                else
                {
                    return "Lỗi khi gọi AI: " + await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return "Lỗi xử lý AI: " + ex.Message;
            }
        }
        public async Task<string> CheckScheduleConflictAsync(string newSchedule, List<string> currentSchedules)
        {
            if (string.IsNullOrWhiteSpace(newSchedule) || currentSchedules == null || currentSchedules.Count == 0)
                return null; // Không có lịch để trùng

            try
            {
                string currentStr = string.Join("\n", currentSchedules.Select(s => $"- {s}"));
                var prompt = $@"
Bạn là trợ lý AI kiểm tra lịch học.
Lịch học của môn mới là: {newSchedule}
Danh sách lịch học các môn sinh viên đã đăng ký:
{currentStr}

Nhiệm vụ của bạn là kiểm tra xem lịch học của môn mới có bị TRÙNG với bất kỳ lịch học nào trong danh sách đã đăng ký hay không.
Chú ý: Hai lịch học trùng nhau nếu chúng diễn ra cùng thứ và cùng thời gian (cùng ca/tiết).
Trả lời: 
- Nếu CÓ trùng, hãy bắt đầu bằng chữ 'CÓ TRÙNG' và giải thích ngắn gọn lịch nào bị trùng.
- Nếu KHÔNG trùng, hãy trả lời chính xác là 'KHÔNG TRÙNG'.";

                var messages = new List<ChatMessage>
                {
                    new ChatMessage { Role = "system", Content = "Bạn là trợ lý AI kiểm tra lịch học." },
                    new ChatMessage { Role = "user", Content = prompt }
                };

                var requestBody = new
                {
                    model = modelName,
                    messages = messages,
                    temperature = 0.1, // Cần độ chính xác cao
                    max_tokens = 150
                };

                string jsonBody = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(responseJson);
                    string reply = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString()?.Trim() ?? "";
                    
                    if (reply.StartsWith("CÓ TRÙNG", StringComparison.OrdinalIgnoreCase))
                    {
                        return reply;
                    }
                    return null; // Không trùng
                }
                else
                {
                    return null; // Bỏ qua nếu AI lỗi để không chặn luồng đăng ký
                }
            }
            catch
            {
                return null;
            }
        }
        public async Task<string> GenerateCourseDescriptionAsync(string courseName, int credits)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                return "Tên môn học không được để trống.";

            try
            {
                var prompt = $@"Bạn là một chuyên gia xây dựng chương trình đào tạo đại học.
Hãy viết một đoạn mô tả ngắn gọn (khoảng 3-4 câu) về nội dung của môn học: '{courseName}' (Số tín chỉ: {credits}).
Yêu cầu:
- Mô tả phải chuẩn mực, học thuật, bám sát nội dung phổ biến của môn học này ở cấp bậc đại học.
- Trả về CHỈ nội dung mô tả, không có phần giải thích, chào hỏi, hay gạch đầu dòng.";

                var messages = new List<ChatMessage>
                {
                    new ChatMessage { Role = "system", Content = "Bạn là trợ lý AI chuyên thiết kế chương trình học." },
                    new ChatMessage { Role = "user", Content = prompt }
                };

                var requestBody = new
                {
                    model = modelName,
                    messages = messages,
                    temperature = 0.5,
                    max_tokens = 200
                };

                string jsonBody = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(responseJson);
                    string reply = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString()?.Trim() ?? "";
                    return reply;
                }
                else
                {
                    return "Lỗi phản hồi từ AI.";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối AI: " + ex.Message;
            }
        }
        public async Task<string> SuggestCourseCreditsAndWeeksAsync(string courseName)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                return "{\"credits\": 3, \"weeks\": 15}";

            try
            {
                var prompt = $@"Bạn là chuyên gia phân tích chương trình đào tạo chuẩn CDIO.
Dựa vào tên môn học: '{courseName}'.
Hãy đề xuất số tín chỉ (credits) và số tuần học (weeks) phù hợp nhất cho môn học này ở cấp bậc đại học.
Trả về CHỈ một chuỗi JSON hợp lệ với định dạng: {{""credits"": X, ""weeks"": Y}}
Trong đó X là số nguyên (thường từ 2-4), Y là số nguyên (thường từ 10-15). Không kèm thêm văn bản nào khác.";

                var messages = new List<ChatMessage>
                {
                    new ChatMessage { Role = "system", Content = "Bạn là hệ thống trả về JSON chuẩn xác." },
                    new ChatMessage { Role = "user", Content = prompt }
                };

                var requestBody = new
                {
                    model = modelName,
                    messages = messages,
                    temperature = 0.1,
                    max_tokens = 50,
                    response_format = new { type = "json_object" }
                };

                string jsonBody = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(responseJson);
                    string reply = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString()?.Trim() ?? "";
                    return reply;
                }
                else
                {
                    return "{\"credits\": 3, \"weeks\": 15}";
                }
            }
            catch
            {
                return "{\"credits\": 3, \"weeks\": 15}";
            }
        }
    }
}
