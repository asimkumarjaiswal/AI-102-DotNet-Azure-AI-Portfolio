using AI102.Application.Features.Vision.DTOs;

namespace AI102.Application.Interfaces
{
    public interface IVisionService
    {
        Task<ImageAnalysisResponseDto> AnalyzeImageAsync(string imageUrl);
        Task<ReadTextResponseDto> ReadTextAsync(string imageUrl);
        Task<ObjectsResponseDto> DetectObjectsAsync(string imageUrl);
        Task<DenseCaptionsResponseDto> GetDenseCaptionsAsync(string imageUrl);
        Task<PeopleResponseDto> DetectPeopleAsync(string imageUrl);
    }
}
