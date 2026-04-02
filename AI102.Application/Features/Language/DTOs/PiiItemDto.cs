
namespace AI102.Domain.Models.Language.DTOs 
{
    public class PiiItemDto
    {
        public string Text { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; }
        public double ConfidenceScore { get; set; }
    }
}
