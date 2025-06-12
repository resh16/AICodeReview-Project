using AIAnalysisService.Api.IServices;
using AIAnalysisService.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AIAnalysisService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalysisController : ControllerBase 
    {
        private readonly IAICodeAnalysis _service;
        public AnalysisController(IAICodeAnalysis service)
        { 
            _service = service;        
        }

        [HttpPost]
        public async Task<IActionResult> Analyze([FromBody] CodeAnalysisRequest model)
        {
            var result = await _service.AnalyzeCodeImprovement(model);
            return Ok(result);
        }
    }
}
