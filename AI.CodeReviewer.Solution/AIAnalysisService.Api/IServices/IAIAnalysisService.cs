using AIAnalysisService.Api.Models;

namespace AIAnalysisService.Api.IServices
{
    public interface IAICodeAnalysis
    {
        Task<CodeAnalysisResponse> AnalyzeCodeImprovement(CodeAnalysisRequest request);
    }
}
