using AIAnalysisService.Api.Models;

namespace AIAnalysisService.Api.IServices
{
    public interface IAICodeAnalysis
    {
        Task<CodeHistoryEntry> AnalyzeCodeImprovement(CodeAnalysisRequest request);
    }
}
