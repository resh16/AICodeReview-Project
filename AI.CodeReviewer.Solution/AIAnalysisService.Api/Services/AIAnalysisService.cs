using AIAnalysisService.Api.IServices;
using AIAnalysisService.Api.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace AIAnalysisService.Api.Services
{
    public class AICodeAnalysis: IAICodeAnalysis 
    {
        public HttpClient _httpClient;
        public AICodeAnalysis(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CodeHistoryEntry> AnalyzeCodeImprovement(CodeAnalysisRequest request)
        {
            var template = await File.ReadAllTextAsync("Prompt/CodeImprovementPrompt.txt");

            var prompt = template
                .Replace("{original}", request.OriginalCode)
                .Replace("{improved}", request.ImprovedCode);

            var payload = new
            {
                model = "codellama",
                prompt = prompt,
                stream = false
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("AI response failed.");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var parsed = JsonDocument.Parse(jsonString);
            var aiResponse = parsed.RootElement.GetProperty("response").GetString();

            bool isImproved = aiResponse.ToLower().Contains("is improved: yes");


            // Simulate analysis (replace with LLM or diff engine later)
            //var isImproved = improvedCode.Length > originalCode.Length; // Dummy logic
            //var feedback = isImproved ? "The improved code seems more complete." : "No significant improvement found.";

            return new CodeHistoryEntry
            {
                OriginalCode = request.OriginalCode,
                ImprovedCode = request.ImprovedCode,
                Timestamp = DateTime.UtcNow,
                Feedback =   aiResponse,
                IsImproved = isImproved
            };
        }
    }
}
