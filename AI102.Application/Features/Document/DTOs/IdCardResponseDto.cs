using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Document.DTOs
{
    public class IdCardResponseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
