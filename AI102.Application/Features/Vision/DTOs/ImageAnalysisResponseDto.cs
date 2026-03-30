using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Vision.DTOs
{
    public class ImageAnalysisResponseDto
    {
        public string Caption { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
    }
}
