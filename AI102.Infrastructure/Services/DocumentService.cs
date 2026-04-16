using AI102.Application.Features.Document.DTOs;
using AI102.Application.Interfaces;
using AI102.Infrastructure.Configurations;
using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Microsoft.Extensions.Options;

namespace AI102.Infrastructure.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly AzureAIOptions _options;

        public DocumentService(IOptions<AzureAIOptions> options)
        {
            _options = options.Value;
        }

        private DocumentAnalysisClient CreateClient()
        {
            return new DocumentAnalysisClient(
                new Uri(_options.Endpoint),
                new AzureKeyCredential(_options.Key));
        }

        public async Task<ReadResponseDto> ReadAsync(string fileUrl)
        {
            var client = CreateClient();

            var operation = await client.AnalyzeDocumentFromUriAsync(
                WaitUntil.Completed,
                "prebuilt-read",
                new Uri(fileUrl));

            var result = operation.Value;

            var response = new ReadResponseDto();

            foreach (var page in result.Pages)
            {
                foreach (var line in page.Lines)
                {
                    response.Lines.Add(line.Content);
                }
            }

            return response;
        }

        public async Task<InvoiceResponseDto> AnalyzeInvoiceAsync(string fileUrl)
        {
            var client = CreateClient();

            var operation = await client.AnalyzeDocumentFromUriAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                new Uri(fileUrl));

            var doc = operation.Value.Documents.FirstOrDefault();

            return new InvoiceResponseDto
            {
                VendorName = doc?.Fields["VendorName"]?.Content,
                CustomerName = doc?.Fields["CustomerName"]?.Content,
                InvoiceId = doc?.Fields["InvoiceId"]?.Content,
                TotalAmount = (decimal?)(doc?.Fields["InvoiceTotal"]?.Value.AsDouble())
            };
        }

        public async Task<ReceiptResponseDto> AnalyzeReceiptAsync(string fileUrl)
        {
            var client = CreateClient();

            var operation = await client.AnalyzeDocumentFromUriAsync(
                WaitUntil.Completed,
                "prebuilt-receipt",
                new Uri(fileUrl));

            var doc = operation.Value.Documents.FirstOrDefault();

            return new ReceiptResponseDto
            {
                MerchantName = doc?.Fields["MerchantName"]?.Content,
                TransactionDate = doc?.Fields["TransactionDate"]?.Value.AsDate().DateTime,
                Total = (decimal?)(doc?.Fields["Total"]?.Value.AsDouble())
            };
        }

        public async Task<IdCardResponseDto> AnalyzeIdCardAsync(string fileUrl)
        {
            var client = CreateClient();

            var operation = await client.AnalyzeDocumentFromUriAsync(
                WaitUntil.Completed,
                "prebuilt-idDocument",
                new Uri(fileUrl));

            var doc = operation.Value.Documents.FirstOrDefault();

            return new IdCardResponseDto
            {
                FirstName = doc?.Fields["FirstName"]?.Content,
                LastName = doc?.Fields["LastName"]?.Content,
                DocumentNumber = doc?.Fields["DocumentNumber"]?.Content,
                DateOfBirth = doc?.Fields["DateOfBirth"]?.Value.AsDate().DateTime
            };
        }
    }
}
