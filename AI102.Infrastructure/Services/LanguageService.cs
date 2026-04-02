using AI102.Application.Interfaces;
using AI102.Domain.Models.Language.DTOs;
using AI102.Infrastructure.Configurations;
using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features
{
    public class LanguageService : ILanguageService
    {
        private readonly AzureAIOptions _options;

        public LanguageService(IOptions<AzureAIOptions> options)
        {
            _options = options.Value;
        }

        private TextAnalyticsClient CreateClient()
        {
            return new TextAnalyticsClient(
                new Uri(_options.Endpoint),
                new AzureKeyCredential(_options.Key));
        }

        public async Task<SentimentResponseDto> AnalyzeSentimentAsync(AnalyzeTextRequestDto request)
        {
            ValidateRequest(request);

            var client = CreateClient();
            var result = await client.AnalyzeSentimentAsync(request.Text, request.Language);

            return new SentimentResponseDto
            {
                Sentiment = result.Value.Sentiment.ToString(),
                PositiveScore = result.Value.ConfidenceScores.Positive,
                NeutralScore = result.Value.ConfidenceScores.Neutral,
                NegativeScore = result.Value.ConfidenceScores.Negative
            };
        }

        public async Task<EntitiesResponseDto> RecognizeEntitiesAsync(AnalyzeTextRequestDto request)
        {
            ValidateRequest(request);

            var client = CreateClient();
            var result = await client.RecognizeEntitiesAsync(request.Text, request.Language);

            var response = new EntitiesResponseDto();

            foreach (var entity in result.Value)
            {
                response.Entities.Add(new EntityItemDto
                {
                    Text = entity.Text,
                    Category = entity.Category.ToString(),
                    SubCategory = entity.SubCategory,
                    ConfidenceScore = entity.ConfidenceScore
                });
            }

            return response;
        }

        public async Task<PiiResponseDto> RecognizePiiAsync(AnalyzeTextRequestDto request)
        {
            ValidateRequest(request);

            var client = CreateClient();
            var result = await client.RecognizePiiEntitiesAsync(request.Text, request.Language);

            var response = new PiiResponseDto
            {
                RedactedText = result.Value.RedactedText
            };

            foreach (var entity in result.Value)
            {
                response.Entities.Add(new PiiItemDto
                {
                    Text = entity.Text,
                    Category = entity.Category.ToString(),
                    SubCategory = entity.SubCategory,
                    ConfidenceScore = entity.ConfidenceScore
                });
            }

            return response;
        }

        public async Task<KeyPhrasesResponseDto> ExtractKeyPhrasesAsync(AnalyzeTextRequestDto request)
        {
            ValidateRequest(request);

            var client = CreateClient();
            var result = await client.ExtractKeyPhrasesAsync(request.Text, request.Language);

            return new KeyPhrasesResponseDto
            {
                KeyPhrases = result.Value.ToList()
            };
        }

        private static void ValidateRequest(AnalyzeTextRequestDto request)
        {
            if (request == null)
                throw new Exception("Request is required.");

            if (string.IsNullOrWhiteSpace(request.Text))
                throw new Exception("Text is required.");
        }
    }
}
