using CodeSubmissionService.Api.Models;

namespace CodeSubmissionService.Api.IServices
{
    public interface ICodeService
    {
        // Analyzes given code and returns a response (feedback)
        CodeAnalysisResponse AnalyzeCode(string code);
    }
}
