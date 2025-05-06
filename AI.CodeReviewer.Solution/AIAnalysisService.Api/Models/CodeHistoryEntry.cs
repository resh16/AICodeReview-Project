namespace AIAnalysisService.Api.Models
{

    // Represents a record of a code analysis session
    public class CodeHistoryEntry
    {
        public string UserId { get; set; }       // To associate history with the user
        public string OriginalCode { get; set; } // Code before applying suggestions
        public string ImprovedCode { get; set; } // Code after applying suggestions
        public DateTime Timestamp { get; set; }  // Time of analysis
        public string Feedback { get; set; }     // Summary of changes or feedback
        public bool IsImproved { get; set; }     // Whether the new code is better
    }


}
