using CodeSubmissionService.Api.Models;

namespace CodeSubmissionService.Api.IServices
{
    public interface ICodeAnalysisService
    {
        // Analyzes given code and returns a response (feedback)
        //CodeAnalysisResponse AnalyzeCode(string code);
        Task<CodeAnalysisResponse> AnalyzeCodeAsync(CodeRequest codeRequest);
    }
}
