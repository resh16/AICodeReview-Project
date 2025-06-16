namespace CodeSubmissionService.Api.DTOs
{
    public class CodeRequestDTO
    {
        public string Code { get; set; }         
        public string Language { get; set; }
        public bool IsImproved { get; set; }

    }
}
