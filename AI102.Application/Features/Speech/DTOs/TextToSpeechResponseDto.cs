using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Speech.DTOs
{
    public class TextToSpeechResponseDto
    {
        public byte[] AudioData { get; set; } = Array.Empty<byte>();
    }
}
