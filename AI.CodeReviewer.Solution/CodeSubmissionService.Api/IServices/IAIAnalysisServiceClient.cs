using CodeSubmissionService.Api.Models;

namespace CodeSubmissionService.Api.IServices
{
    public interface IAIAnalysisServiceClient
    {
        Task<CodeAnalysisResponse> SendCodeForAnalysisAsync(string originalCode, string improvedCode, string language);
    }
}
