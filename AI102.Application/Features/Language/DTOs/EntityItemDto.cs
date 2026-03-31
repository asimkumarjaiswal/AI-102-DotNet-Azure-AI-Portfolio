
namespace AI102.Domain.Models.Language.DTOs
{
    public class EntityItemDto
    {
        public string Text { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; }
        public double ConfidenceScore { get; set; }
    }
}
