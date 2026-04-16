using AI102.Application.Features.Document.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI102.Application.Interfaces
{
    public interface IDocumentService
    {
        Task<ReadResponseDto> ReadAsync(string fileUrl);
        Task<InvoiceResponseDto> AnalyzeInvoiceAsync(string fileUrl);
        Task<ReceiptResponseDto> AnalyzeReceiptAsync(string fileUrl);
        Task<IdCardResponseDto> AnalyzeIdCardAsync(string fileUrl);
    }
}
