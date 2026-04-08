using AI102.Application.Interfaces;
using AI102.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AI102.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisionController : ControllerBase
    {
        private readonly IVisionService _visionService;

        public VisionController(IVisionService visionService)
        {
            _visionService = visionService;
        }

        [HttpPost("analyze")]
        public async Task<IActionResult> Analyze([FromQuery] string imageUrl)
        {
            var result = await _visionService.AnalyzeImageAsync(imageUrl);
            return Ok(ApiResponse<object>.Ok(result, "Image analyzed successfully"));
        }

        [HttpPost("read-text")]
        public async Task<IActionResult> ReadText([FromQuery] string imageUrl)
        {
            var result = await _visionService.ReadTextAsync(imageUrl);
            return Ok(ApiResponse<object>.Ok(result, "Text extracted successfully"));
        }

        [HttpPost("detect-objects")]
        public async Task<IActionResult> DetectObjects([FromQuery] string imageUrl)
        {
            var result = await _visionService.DetectObjectsAsync(imageUrl);
            return Ok(ApiResponse<object>.Ok(result, "Objects detected successfully"));
        }

        [HttpPost("dense-captions")]
        public async Task<IActionResult> DenseCaptions([FromQuery] string imageUrl)
        {
            var result = await _visionService.GetDenseCaptionsAsync(imageUrl);
            return Ok(ApiResponse<object>.Ok(result, "Dense captions generated successfully"));
        }
    }
}
