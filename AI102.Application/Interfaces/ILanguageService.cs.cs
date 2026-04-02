using AI102.Domain.Models.Language.DTOs;
using AI102.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Interfaces
{
    public interface ILanguageService
    {
        Task<SentimentResponseDto> AnalyzeSentimentAsync(AnalyzeTextRequestDto request);
        Task<EntitiesResponseDto> RecognizeEntitiesAsync(AnalyzeTextRequestDto request);
        Task<PiiResponseDto> RecognizePiiAsync(AnalyzeTextRequestDto request);
        Task<KeyPhrasesResponseDto> ExtractKeyPhrasesAsync(AnalyzeTextRequestDto request);
    }
}
