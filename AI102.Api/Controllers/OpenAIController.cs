using AI102.Application.Features.OpenAI.DTOs;
using AI102.Application.Interfaces;
using AI102.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AI102.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpenAIController : ControllerBase
    {
        private readonly IOpenAIService _service;

        public OpenAIController(IOpenAIService service)
        {
            _service = service;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat(ChatRequestDto request)
        {
            var result = await _service.ChatAsync(request.Prompt);
            return Ok(ApiResponse<object>.Ok(result, "Chat response generated"));
        }

        [HttpPost("summarize")]
        public async Task<IActionResult> Summarize(ChatRequestDto request)
        {
            var result = await _service.SummarizeAsync(request.Prompt);
            return Ok(ApiResponse<object>.Ok(result, "Summary generated"));
        }

        [HttpPost("extract")]
        public async Task<IActionResult> Extract(ChatRequestDto request)
        {
            var result = await _service.ExtractAsync(request.Prompt);
            return Ok(ApiResponse<object>.Ok(result, "Key points extracted"));
        }

        [HttpPost("rewrite")]
        public async Task<IActionResult> Rewrite(ChatRequestDto request)
        {
            var result = await _service.RewriteAsync(request.Prompt);
            return Ok(ApiResponse<object>.Ok(result, "Text rewritten"));
        }
    }
}
