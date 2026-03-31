
namespace AI102.Domain.Models.Language.DTOs
{
    public class AnalyzeTextRequestDto
    {
        public string Text { get; set; } = string.Empty;
        public string Language { get; set; } = "en";
    }
}
