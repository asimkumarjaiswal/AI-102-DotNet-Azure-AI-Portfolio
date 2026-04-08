using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Vision.DTOs
{
    public class DenseCaptionsResponseDto
    {
        public List<DenseCaptionItemDto> Captions { get; set; } = new();
    }
}
