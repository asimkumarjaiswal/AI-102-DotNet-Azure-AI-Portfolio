using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Document.DTOs
{
    public class InvoiceResponseDto
    {
        public string? VendorName { get; set; }
        public string? CustomerName { get; set; }
        public string? InvoiceId { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
