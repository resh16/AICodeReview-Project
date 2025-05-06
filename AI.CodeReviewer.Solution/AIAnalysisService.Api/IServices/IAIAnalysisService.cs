using AIAnalysisService.Api.Models;

namespace AIAnalysisService.Api.IServices
{
    public interface IAICodeAnalysis
    {
        Task<CodeHistoryEntry> AnalyzeCodeImprovement(string originalCode, string improvedCode);
    }
}
