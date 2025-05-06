using AIAnalysisService.Api.IServices;
using AIAnalysisService.Api.Models;

namespace AIAnalysisService.Api.Services
{
    public class AICodeAnalysis: IAICodeAnalysis 
    {
        public async Task<CodeHistoryEntry> AnalyzeCodeImprovement(string originalCode, string improvedCode)
        {
            // Simulate analysis (replace with LLM or diff engine later)
            var isImproved = improvedCode.Length > originalCode.Length; // Dummy logic
            var feedback = isImproved ? "The improved code seems more complete." : "No significant improvement found.";

            return new CodeHistoryEntry
            {
                OriginalCode = originalCode,
                ImprovedCode = improvedCode,
                Timestamp = DateTime.UtcNow,
                Feedback = feedback,
                IsImproved = isImproved
            };
        }
    }
}
