using AI102.Application.Features.Speech.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Interfaces
{
    public interface ISpeechService
    {
        Task<SpeechToTextResponseDto> SpeechToTextAsync(IFormFile audioFile);
        Task<TextToSpeechResponseDto> TextToSpeechAsync(string text);
    }
}
