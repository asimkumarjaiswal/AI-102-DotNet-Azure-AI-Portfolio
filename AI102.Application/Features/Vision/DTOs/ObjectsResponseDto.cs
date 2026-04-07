using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Vision.DTOs
{
    public class ObjectsResponseDto
    {
        public List<DetectedObjectDto> Objects { get; set; } = new();
    }
}
