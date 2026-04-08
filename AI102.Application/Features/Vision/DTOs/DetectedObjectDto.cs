using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Vision.DTOs
{
    public class DetectedObjectDto
    {
        public string Name { get; set; } = string.Empty;
        public double Confidence { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
