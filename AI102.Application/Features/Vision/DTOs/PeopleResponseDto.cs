using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Vision.DTOs
{
    public class PeopleResponseDto
    {
        public List<DetectedPersonDto> People { get; set; } = new();
    }
}
