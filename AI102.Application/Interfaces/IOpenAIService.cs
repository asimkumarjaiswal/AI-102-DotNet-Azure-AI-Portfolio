using AI102.Application.Features.OpenAI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Interfaces
{
    public interface IOpenAIService
    {
        Task<ChatResponseDto> ChatAsync(string prompt);
        Task<ChatResponseDto> SummarizeAsync(string text);
        Task<ChatResponseDto> ExtractAsync(string text);
        Task<ChatResponseDto> RewriteAsync(string text);
    }
}
