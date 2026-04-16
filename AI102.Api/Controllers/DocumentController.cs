using AI102.Application.Interfaces;
using AI102.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AI102.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _service;

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        [HttpPost("read")]
        public async Task<IActionResult> Read([FromQuery] string fileUrl)
        {
            var result = await _service.ReadAsync(fileUrl);
            return Ok(ApiResponse<object>.Ok(result, "Document read successfully"));
        }

        [HttpPost("invoice")]
        public async Task<IActionResult> Invoice([FromQuery] string fileUrl)
        {
            var result = await _service.AnalyzeInvoiceAsync(fileUrl);
            return Ok(ApiResponse<object>.Ok(result, "Invoice analyzed successfully"));
        }

        [HttpPost("receipt")]
        public async Task<IActionResult> Receipt([FromQuery] string fileUrl)
        {
            var result = await _service.AnalyzeReceiptAsync(fileUrl);
            return Ok(ApiResponse<object>.Ok(result, "Receipt analyzed successfully"));
        }

        [HttpPost("id-card")]
        public async Task<IActionResult> IdCard([FromQuery] string fileUrl)
        {
            var result = await _service.AnalyzeIdCardAsync(fileUrl);
            return Ok(ApiResponse<object>.Ok(result, "ID card analyzed successfully"));
        }
    }
}
