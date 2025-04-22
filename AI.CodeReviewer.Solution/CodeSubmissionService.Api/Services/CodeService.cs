using CodeSubmissionService.Api.IServices;
using CodeSubmissionService.Api.Models;

namespace CodeSubmissionService.Api.Services
{
    public class CodeService : ICodeService
    {
        public CodeAnalysisResponse AnalyzeCode(string code)
        {
            // Placeholder for actual code analysis logic
            return new CodeAnalysisResponse
            {
                Feedback = "Code looks good !!.",
                IsSuccess = true
            };
        }
    }
    
}
