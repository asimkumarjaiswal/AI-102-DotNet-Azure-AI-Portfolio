using AI102.Application.Features.Vision.DTOs;
using AI102.Application.Interfaces;
using AI102.Infrastructure.Configurations;
using Azure;
using Azure.AI.Vision.ImageAnalysis;
using Microsoft.Extensions.Options;

namespace AI102.Infrastructure.Services;

public class VisionService : IVisionService
{
    private readonly AzureAIOptions _options;

    public VisionService(IOptions<AzureAIOptions> options)
    {
        _options = options.Value;
    }

    public async Task<ImageAnalysisResponseDto> AnalyzeImageAsync(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new Exception("Image URL is required.");

        var client = new ImageAnalysisClient(new Uri(_options.Endpoint),new AzureKeyCredential(_options.Key));

        var result = await client.AnalyzeAsync(new Uri(imageUrl),VisualFeatures.Caption | VisualFeatures.Tags);

        var response = new ImageAnalysisResponseDto();

        if (result.Value.Caption != null)
        {
            response.Caption = result.Value.Caption.Text;
        }

        if (result.Value.Tags != null)
        {
            response.Tags = result.Value.Tags.Values.Select(t => t.Name).ToList()!;
        }

        return response;
    }
}