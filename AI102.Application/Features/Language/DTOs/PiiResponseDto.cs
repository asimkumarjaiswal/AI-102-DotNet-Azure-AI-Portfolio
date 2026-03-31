
namespace AI102.Domain.Models.Language.DTOs 
{
    public class PiiResponseDto
    {
        public string RedactedText { get; set; } = string.Empty;
        public List<PiiItemDto> Entities { get; set; } = new();
    }
}
