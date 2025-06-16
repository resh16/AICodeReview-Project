namespace CodeSubmissionService.Api.Models
{
    public class CodeRequest // This class is used to receive the code and language from the client.
    {
        public string Code { get; set; }         // Code submitted by the user
        public string Language { get; set; }     // Optional: language of the code (e.g., csharp, java)
        public bool IsImproved { get; set; }
    }
}
