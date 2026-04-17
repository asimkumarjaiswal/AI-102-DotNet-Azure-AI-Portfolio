using AI102.Application.Interfaces;
using AI102.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AI102.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeechController : ControllerBase
    {
        private readonly ISpeechService _service;

        public SpeechController(ISpeechService service)
        {
            _service = service;
        }

        [HttpPost("speech-to-text")]
        public async Task<IActionResult> SpeechToText(IFormFile audioFile)
        {
            var result = await _service.SpeechToTextAsync(audioFile);
            return Ok(ApiResponse<object>.Ok(result, "Speech converted to text"));
        }

        [HttpPost("text-to-speech")]
        public async Task<IActionResult> TextToSpeech([FromQuery] string text)
        {
            var result = await _service.TextToSpeechAsync(text);
            return File(result.AudioData, "audio/wav");
        }
    }
}
