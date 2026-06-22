using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        string apiKey = "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"; // From API.config
        
        string systemPrompt = @"Phản hồi CHỈ bằng JSON: { ""MSSV"": ""..."", ""Fname"": ""..."", ""Lname"": ""..."" }";
        
        // Small 1x1 transparent pixel base64 for test
        string base64Image = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mNkYAAAAAYAAjCB0C8AAAAASUVORK5CYII=";
        string dataUri = $"data:image/png;base64,{base64Image}";

        var requestBody = new
        {
            model = "llama-3.2-90b-vision-preview",
            messages = new object[]
            {
                new { role = "system", content = systemPrompt },
                new 
                { 
                    role = "user", 
                    content = new object[] 
                    {
                        new { type = "text", text = "Test" },
                        new { type = "image_url", image_url = new { url = dataUri } }
                    }
                }
            },
            temperature = 0.1,
            response_format = new { type = "json_object" }
        };

        string jsonBody = JsonSerializer.Serialize(requestBody);
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.groq.com/openai/v1/chat/completions")
        {
            Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var response = await client.SendAsync(request);
        Console.WriteLine($"Status: {response.StatusCode}");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}
