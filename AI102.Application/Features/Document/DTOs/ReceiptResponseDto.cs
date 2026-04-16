using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Features.Document.DTOs
{
    public class ReceiptResponseDto
    {
        public string? MerchantName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Total { get; set; }
    }
}
