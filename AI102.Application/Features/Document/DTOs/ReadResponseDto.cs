using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Document.DTOs
{
    public class ReadResponseDto
    {
        public List<string> Lines { get; set; } = new();
    }
}
