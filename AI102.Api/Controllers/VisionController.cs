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
    }
}
