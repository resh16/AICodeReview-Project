using CodeSubmissionService.Api.IServices;
using CodeSubmissionService.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeSubmissionService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodeController : ControllerBase
    {
        private readonly ICodeService _codeService;
        public CodeController(ICodeService codeservice)
        {
            _codeService = codeservice;
        }


        [Authorize]
        [HttpPost("codeSubmit")]
        public IActionResult SubmitCode([FromBody] CodeSubmissionRequest request)
        {
            // Call the service to analyze the code
            var result = _codeService.AnalyzeCode(request.CodeContent);

            // Return the feedback to the user
            return Ok(result);
        }


    }
}
