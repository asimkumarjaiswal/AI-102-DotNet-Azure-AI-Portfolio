
namespace AI102.Domain.Models.Language.DTOs 
{
    public class SentimentResponseDto
    {
        public string Sentiment { get; set; } = string.Empty;
        public double PositiveScore { get; set; }
        public double NeutralScore { get; set; }
        public double NegativeScore { get; set; }
    }
}
