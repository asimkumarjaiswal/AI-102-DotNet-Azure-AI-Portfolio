using AI102.Application.Interfaces;
using AI102.Domain.Models.Language.DTOs;
using AI102.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AI102.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost("sentiment")]
        public async Task<IActionResult> AnalyzeSentiment([FromBody] AnalyzeTextRequestDto request)
        {
            var result = await _languageService.AnalyzeSentimentAsync(request);
            return Ok(ApiResponse<object>.Ok(result, "Sentiment analyzed successfully"));
        }

        [HttpPost("entities")]
        public async Task<IActionResult> RecognizeEntities([FromBody] AnalyzeTextRequestDto request)
        {
            var result = await _languageService.RecognizeEntitiesAsync(request);
            return Ok(ApiResponse<object>.Ok(result, "Entities recognized successfully"));
        }

        [HttpPost("pii")]
        public async Task<IActionResult> RecognizePii([FromBody] AnalyzeTextRequestDto request)
        {
            var result = await _languageService.RecognizePiiAsync(request);
            return Ok(ApiResponse<object>.Ok(result, "PII analyzed successfully"));
        }

        [HttpPost("keyphrases")]
        public async Task<IActionResult> ExtractKeyPhrases([FromBody] AnalyzeTextRequestDto request)
        {
            var result = await _languageService.ExtractKeyPhrasesAsync(request);
            return Ok(ApiResponse<object>.Ok(result, "Key phrases extracted successfully"));
        }
    }
}
