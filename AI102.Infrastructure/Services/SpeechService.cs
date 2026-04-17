using AI102.Application.Features.Speech.DTOs;
using AI102.Application.Interfaces;
using AI102.Infrastructure.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Options;

namespace AI102.Infrastructure.Services
{
    public class SpeechService : ISpeechService
    {
        private readonly AzureAIOptions _options;

        public SpeechService(IOptions<AzureAIOptions> options)
        {
            _options = options.Value;
        }

        private SpeechConfig CreateSpeechConfig()
        {
            // IMPORTANT: For Speech use Region instead of Endpoint
            return SpeechConfig.FromSubscription(_options.Key, "centralindia");
        }

        public async Task<SpeechToTextResponseDto> SpeechToTextAsync(IFormFile audioFile)
        {
            if (audioFile == null || audioFile.Length == 0)
                throw new Exception("Audio file is required.");

            var config = CreateSpeechConfig();

            using var stream = audioFile.OpenReadStream();
            using var audioInputStream = AudioInputStream.CreatePushStream();
            // Copy the audio file stream into the push stream
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                if (bytesRead == buffer.Length)
                {
                    audioInputStream.Write(buffer);
                }
                else
                {
                    var tempBuffer = new byte[bytesRead];
                    Array.Copy(buffer, tempBuffer, bytesRead);
                    audioInputStream.Write(tempBuffer);
                }
            }
            audioInputStream.Close();

            using var audioInput = AudioConfig.FromStreamInput(audioInputStream);
            using var recognizer = new SpeechRecognizer(config, audioInput);

            var result = await recognizer.RecognizeOnceAsync();

            return new SpeechToTextResponseDto
            {
                Text = result.Text
            };
        }

        public async Task<TextToSpeechResponseDto> TextToSpeechAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("Text is required.");

            var config = CreateSpeechConfig();

            using var synthesizer = new SpeechSynthesizer(config, null);

            var result = await synthesizer.SpeakTextAsync(text);

            return new TextToSpeechResponseDto
            {
                AudioData = result.AudioData
            };
        }
    }
}
