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

        var client = new ImageAnalysisClient(new Uri(_options.Endpoint), new AzureKeyCredential(_options.Key));
        try
        {
            var result = await client.AnalyzeAsync(new Uri(imageUrl), VisualFeatures.Caption | VisualFeatures.Tags);
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
        catch (RequestFailedException ex)
        {

            throw new Exception(ex.Message);
        }

    }

    public async Task<ReadTextResponseDto> ReadTextAsync(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new Exception("Image URL is required.");

        var client = new ImageAnalysisClient(
            new Uri(_options.Endpoint),
            new AzureKeyCredential(_options.Key));

        var result = await client.AnalyzeAsync(
            new Uri(imageUrl),
            VisualFeatures.Read);

        var response = new ReadTextResponseDto();

        if (result.Value.Read != null)
        {
            foreach (var block in result.Value.Read.Blocks)
            {
                foreach (var line in block.Lines)
                {
                    response.Lines.Add(line.Text);
                }
            }
        }

        return response;
    }

    public async Task<ObjectsResponseDto> DetectObjectsAsync(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new Exception("Image URL is required.");

        var client = new ImageAnalysisClient(
            new Uri(_options.Endpoint),
            new AzureKeyCredential(_options.Key));

        var result = await client.AnalyzeAsync(
            new Uri(imageUrl),
            VisualFeatures.Objects);

        var response = new ObjectsResponseDto();

        if (result.Value.Objects != null)
        {
            foreach (var obj in result.Value.Objects.Values)
            {
                response.Objects.Add(new DetectedObjectDto
                {
                    Name = obj.Tags.FirstOrDefault()?.Name ?? "Unknown",
                    //Confidence = obj.confidence, // Confidence is not available in the current SDK version for object detection
                    X = obj.BoundingBox.X,
                    Y = obj.BoundingBox.Y,
                    Width = obj.BoundingBox.Width,
                    Height = obj.BoundingBox.Height
                });
            }
        }

        return response;
    }

    public async Task<DenseCaptionsResponseDto> GetDenseCaptionsAsync(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new Exception("Image URL is required.");

        var client = new ImageAnalysisClient(
            new Uri(_options.Endpoint),
            new AzureKeyCredential(_options.Key));

        var result = await client.AnalyzeAsync(
            new Uri(imageUrl),
            VisualFeatures.DenseCaptions);

        var response = new DenseCaptionsResponseDto();

        if (result.Value.DenseCaptions != null)
        {
            foreach (var caption in result.Value.DenseCaptions.Values)
            {
                response.Captions.Add(new DenseCaptionItemDto
                {
                    Text = caption.Text,
                    Confidence = caption.Confidence,
                    X = caption.BoundingBox.X,
                    Y = caption.BoundingBox.Y,
                    Width = caption.BoundingBox.Width,
                    Height = caption.BoundingBox.Height
                });
            }
        }

        return response;
    }

    public async Task<PeopleResponseDto> DetectPeopleAsync(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new Exception("Image URL is required.");

        var client = new ImageAnalysisClient(
            new Uri(_options.Endpoint),
            new AzureKeyCredential(_options.Key));

        var result = await client.AnalyzeAsync(
            new Uri(imageUrl),
            VisualFeatures.People);

        var response = new PeopleResponseDto();

        if (result.Value.People != null)
        {
            foreach (var person in result.Value.People.Values)
            {
                response.People.Add(new DetectedPersonDto
                {
                    Confidence = person.Confidence,
                    X = person.BoundingBox.X,
                    Y = person.BoundingBox.Y,
                    Width = person.BoundingBox.Width,
                    Height = person.BoundingBox.Height
                });
            }
        }

        return response;
    }
}