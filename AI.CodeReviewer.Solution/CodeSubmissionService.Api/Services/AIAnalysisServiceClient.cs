using System.Net.Http;
using System.Text.Json;
using System.Text;
using CodeSubmissionService.Api.IServices;
using CodeSubmissionService.Api.Models;

namespace CodeSubmissionService.Api.Services
{
    public class AIAnalysisServiceClient : IAIAnalysisServiceClient
    {
        private readonly HttpClient _httpClient;
        public AIAnalysisServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CodeAnalysisResponse> SendCodeForAnalysisAsync(string originalCode, string improvedCode, string language)
        {
            var model = new
            {
                OriginalCode = originalCode,
                ImprovedCode = improvedCode,
                Language = language
            };

            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7244/api/Analysis", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var historyEntry = JsonSerializer.Deserialize<CodeAnalysisResponse>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Map the received CodeHistoryEntry to your desired return model
            return new CodeAnalysisResponse
            {
                Feedback = historyEntry.Feedback,
                IsImproved = historyEntry.IsImproved,
                OriginalCode = historyEntry.OriginalCode,
                ImprovedCode = historyEntry.ImprovedCode
            };


            
        }
    }
}
