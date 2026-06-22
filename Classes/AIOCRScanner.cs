using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tesseract;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace ProjectMonHoc.Classes
{
    public class AIOCRScanner
    {
        private readonly string _groqApiKey;
        private readonly string _groqModel;
        private static readonly HttpClient client = new HttpClient();

        public AIOCRScanner()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = "API.config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            _groqApiKey = config.AppSettings.Settings["GroqApiKey"]?.Value ?? "";
            _groqModel = config.AppSettings.Settings["GroqModel"]?.Value ?? "llama-3.3-70b-versatile";
        }

        public class OCRResult
        {
            public string MSSV { get; set; } = "";
            public string Fname { get; set; } = "";
            public string Lname { get; set; } = "";
            public bool Success { get; set; } = false;
        }

        public async Task<OCRResult> ScanCardAsync(string imagePath)
        {
            if (string.IsNullOrEmpty(_groqApiKey) || _groqApiKey.Contains("your_api_key"))
            {
                return new OCRResult { Success = false };
            }

            try
            {
                // BƯỚC 1: ĐỌC CHỮ TRÊN ẢNH BẰNG TESSERACT OCR
                string rawText = ExtractTextWithTesseract(imagePath);
                if (string.IsNullOrWhiteSpace(rawText))
                {
                    Console.WriteLine("Tesseract could not find any text.");
                    return new OCRResult { Success = false };
                }

                // BƯỚC 2: DÙNG GROQ ĐỂ BÓC TÁCH THÔNG TIN TỪ RAW TEXT
                return await ParseTextWithGroq(rawText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in AI OCR Scanner: " + ex.Message);
            }

            return new OCRResult { Success = false };
        }

        private string ExtractTextWithTesseract(string imagePath)
        {
            string tempProcessedPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
            try
            {
                // Tiền xử lý ảnh với Emgu CV để tăng độ chính xác (Grayscale + Tăng kích thước)
                using (Mat img = CvInvoke.Imread(imagePath, ImreadModes.ColorBgr))
                {
                    using (Mat gray = new Mat())
                    {
                        CvInvoke.CvtColor(img, gray, ColorConversion.Bgr2Gray);
                        
                        // Tăng gấp đôi kích thước để chữ rõ nét hơn
                        using (Mat resized = new Mat())
                        {
                            CvInvoke.Resize(gray, resized, new Size(), 2.0, 2.0, Inter.Cubic);
                            
                            // Có thể thêm Adaptive Threshold nếu ảnh bị tối/mờ
                            // CvInvoke.AdaptiveThreshold(resized, resized, 255, AdaptiveThresholdType.GaussianC, ThresholdType.Binary, 11, 2);
                            
                            resized.Save(tempProcessedPath);
                        }
                    }
                }

                // Thư mục chứa data tiếng Việt
                string tessDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata");
                
                using (var engine = new TesseractEngine(tessDataPath, "vie", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(tempProcessedPath))
                    {
                        using (var page = engine.Process(img))
                        {
                            return page.GetText();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tesseract Error: " + ex.Message);
                return "";
            }
            finally
            {
                if (File.Exists(tempProcessedPath))
                {
                    try { File.Delete(tempProcessedPath); } catch { }
                }
            }
        }

        private async Task<OCRResult> ParseTextWithGroq(string rawText)
        {
            try
            {
                string systemPrompt = @"Bạn là chuyên gia trích xuất dữ liệu thông minh.
Dưới đây là đoạn văn bản thô quét OCR từ ảnh thẻ sinh viên/nhân viên.
Nhiệm vụ của bạn là trích xuất 3 thông tin: MSSV, Fname (Họ và Tên đệm) và Lname (Tên).

QUY TẮC CỰC KỲ QUAN TRỌNG ĐỐI VỚI TÊN NGƯỜI VIỆT NAM:
1. Tìm toàn bộ họ và tên đầy đủ của người đó.
2. Từ cuối cùng của họ tên đầy đủ CHẮC CHẮN LÀ Lname (Tên chính).
3. Toàn bộ các từ đứng trước từ cuối cùng CHẮC CHẮN LÀ Fname (Họ và Tên đệm).
Ví dụ: 'TRẦN GIA KIỆT' -> Fname: 'TRẦN GIA', Lname: 'KIỆT'
Ví dụ: 'Nguyễn Thị Thu Hà' -> Fname: 'Nguyễn Thị Thu', Lname: 'Hà'

Lưu ý thêm:
- Sửa các lỗi chính tả nhỏ do OCR quét sai (ví dụ: 'TRÁN' -> 'TRẦN') nếu nhận ra tên tiếng Việt hợp lý.
- MSSV thường là dãy số tự nhiên (khoảng 8 số).

Phản hồi CHỈ BẰNG 1 CHUỖI JSON ĐÚNG CHUẨN như sau:
{ ""MSSV"": ""..."", ""Fname"": ""..."", ""Lname"": ""..."" }
Tuyệt đối không giải thích, không bọc trong markdown.";

                string userPrompt = "RAW TEXT:\n" + rawText;

                var requestBody = new
                {
                    model = _groqModel,
                    messages = new[]
                    {
                        new { role = "system", content = systemPrompt },
                        new { role = "user", content = userPrompt }
                    },
                    temperature = 0.1
                };

                string jsonBody = JsonSerializer.Serialize(requestBody);
                string url = "https://api.groq.com/openai/v1/chat/completions";

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _groqApiKey);

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(responseContent))
                    {
                        var choices = doc.RootElement.GetProperty("choices");
                        if (choices.GetArrayLength() > 0)
                        {
                            string text = choices[0].GetProperty("message").GetProperty("content").GetString() ?? "";

                            // Lọc JSON
                            int startIndex = text.IndexOf('{');
                            int endIndex = text.LastIndexOf('}');

                            if (startIndex >= 0 && endIndex >= startIndex)
                            {
                                string cleanJson = text.Substring(startIndex, endIndex - startIndex + 1);
                                using (JsonDocument innerDoc = JsonDocument.Parse(cleanJson))
                                {
                                    string mssv = innerDoc.RootElement.TryGetProperty("MSSV", out var mssvProp) ? mssvProp.GetString() ?? "" : "";
                                    string fname = innerDoc.RootElement.TryGetProperty("Fname", out var fnameProp) ? fnameProp.GetString() ?? "" : "";
                                    string lname = innerDoc.RootElement.TryGetProperty("Lname", out var lnameProp) ? lnameProp.GetString() ?? "" : "";

                                    return new OCRResult
                                    {
                                        MSSV = mssv,
                                        Fname = fname,
                                        Lname = lname,
                                        Success = true
                                    };
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Groq Text API Error: " + await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Groq Error: " + ex.Message);
            }

            return new OCRResult { Success = false };
        }
    }
}
