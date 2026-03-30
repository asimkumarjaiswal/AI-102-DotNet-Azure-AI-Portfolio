using AI102.Application.Features.Vision.DTOs;

namespace AI102.Application.Interfaces
{
    public interface IVisionService
    {
        Task<ImageAnalysisResponseDto> AnalyzeImageAsync(string imageUrl);
    }
}
