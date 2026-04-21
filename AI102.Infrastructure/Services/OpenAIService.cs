using AI102.Application.Features.OpenAI.DTOs;
using AI102.Application.Interfaces;
using AI102.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Infrastructure.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly AzureAIOptions _options;
        private readonly OpenAIClient _client;

        public OpenAIService(IOptions<AzureAIOptions> options)
        {
            _options = options.Value;

            _client = new OpenAIClient(
                new ApiKeyCredential(_options.OpenAIKey),
                new OpenAIClientOptions
                {
                    // If you need to set a custom endpoint, set it here:
                    // Endpoint = new Uri(_options.OpenAIEndpoint)
                }
            );
        }

        private async Task<string> SendPrompt(string prompt)
        {
            var chatClient = _client.GetChatClient(_options.DeploymentName);
            var response = await chatClient.CompleteChatAsync(
                new ChatMessage[]
                {
                    ChatMessage.CreateSystemMessage("You are a helpful AI assistant."),
                    ChatMessage.CreateUserMessage(prompt)
                },
                new ChatCompletionOptions
                {
                    Temperature = 0.7f,
                    MaxOutputTokenCount = 800
                });

            // Fix: Extract text from ChatMessageContent
            var content = response.Value.Content;
            var stringBuilder = new StringBuilder();
            foreach (var part in content)
            {
                if (part.Kind == ChatMessageContentPartKind.Text && !string.IsNullOrEmpty(part.Text))
                {
                    stringBuilder.Append(part.Text);
                }
            }
            return stringBuilder.ToString();
        }

        public async Task<ChatResponseDto> ChatAsync(string prompt)
        {
            var result = await SendPrompt(prompt);

            return new ChatResponseDto { Response = result };
        }

        public async Task<ChatResponseDto> SummarizeAsync(string text)
        {
            var prompt = $"Summarize the following text:\n{text}";
            var result = await SendPrompt(prompt);

            return new ChatResponseDto { Response = result };
        }

        public async Task<ChatResponseDto> ExtractAsync(string text)
        {
            var prompt = $"Extract key points from the following text:\n{text}";
            var result = await SendPrompt(prompt);

            return new ChatResponseDto { Response = result };
        }

        public async Task<ChatResponseDto> RewriteAsync(string text)
        {
            var prompt = $"Rewrite the following text professionally:\n{text}";
            var result = await SendPrompt(prompt);

            return new ChatResponseDto { Response = result };
        }
    }
}
