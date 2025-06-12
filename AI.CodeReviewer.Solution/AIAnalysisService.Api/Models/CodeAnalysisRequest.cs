namespace AIAnalysisService.Api.Models
{
    public class CodeAnalysisRequest
    {
        public string OriginalCode { get; set; }
        public string ImprovedCode { get; set; }
        public string Language { get; set; } = "csharp";
    }
}
