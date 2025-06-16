using CodeSubmissionService.Api.DTOs;
using CodeSubmissionService.Api.IServices;
using CodeSubmissionService.Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace CodeSubmissionService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodeController : ControllerBase
    {
        private readonly ICodeAnalysisService _codeService;
        public CodeController(ICodeAnalysisService codeservice)
        {
            _codeService = codeservice;
        }


        
        [HttpPost("codeSubmit")]
        public async Task<IActionResult> SubmitCode([FromBody] CodeRequestDTO request)
        {

            if (string.IsNullOrWhiteSpace(request.Code))
                return BadRequest("Code cannot be empty");

            var result = await _codeService.AnalyzeCodeAsync(new CodeRequest
            {
                Code = request.Code,
                Language = request.Language
            });
            return Ok(result);
            
        }


    }
}
