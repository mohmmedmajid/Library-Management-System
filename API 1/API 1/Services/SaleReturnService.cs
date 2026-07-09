using API_1.DTOs.SaleReturn;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class SaleReturnService : ISaleReturnService
    {
        private readonly ISaleReturnRepository _saleReturnRepository;
        private readonly IInvoiceSearchRepository _invoiceSearchRepository;

        public SaleReturnService(ISaleReturnRepository saleReturnRepository, IInvoiceSearchRepository invoiceSearchRepository)
        {
            _saleReturnRepository = saleReturnRepository;
            _invoiceSearchRepository = invoiceSearchRepository;
        }

        public async Task<int> CreateAsync(CreateSaleReturnDTO dto)
        {
            if (dto.OriginalInvoiceID <= 0)
                throw new ArgumentException("Original invoice is required");

            if (dto.Details == null || dto.Details.Count == 0)
                throw new ArgumentException("At least one return line is required");

            if (string.IsNullOrWhiteSpace(dto.RefundMethod))
                throw new ArgumentException("Refund method is required");

            if (dto.PaymentMethodID <= 0)
                throw new ArgumentException("Payment method is required");

            var returnable = await _invoiceSearchRepository.GetReturnableDetailsAsync(dto.OriginalInvoiceID);

            foreach (var line in dto.Details)
            {
                if (line.ReturnedQuantity <= 0)
                    throw new ArgumentException("Returned quantity must be greater than zero");

                var match = returnable.FirstOrDefault(r => r.InvoiceDetailID == line.InvoiceDetailID);
                if (match == null)
                    throw new Exception("Invoice detail not found or not returnable");

                if (line.ReturnedQuantity > match.ReturnableQuantity)
                    throw new Exception($"Returned quantity exceeds returnable quantity for product {match.ProductName}");
            }

            var saleReturnId = await _saleReturnRepository.InsertHeaderAsync(
                dto.OriginalInvoiceID,
                dto.CustomerID,
                dto.RefundMethod,
                dto.PaymentMethodID,
                dto.Notes?.Trim(),
                dto.CreatedBy
            );

            foreach (var line in dto.Details)
            {
                await _saleReturnRepository.InsertDetailAsync(saleReturnId, line.InvoiceDetailID, line.ReturnedQuantity);
            }

            await _saleReturnRepository.FinalizeAsync(saleReturnId, dto.CreatedBy);

            return saleReturnId;
        }

        public async Task<SaleReturn?> GetByIdAsync(int saleReturnId)
        {
            return await _saleReturnRepository.GetByIdAsync(saleReturnId);
        }

        public async Task<List<SaleReturnDetail>> GetDetailsAsync(int saleReturnId)
        {
            return await _saleReturnRepository.GetDetailsBySaleReturnIdAsync(saleReturnId);
        }

        public async Task<List<SaleReturn>> GetAllAsync(DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && endDate.HasValue && startDate > endDate)
                throw new ArgumentException("Start date cannot be after end date");

            return await _saleReturnRepository.GetAllAsync(null, startDate, endDate);
        }

        public async Task<InvoiceSearchResult?> SearchByNumberAsync(SearchInvoiceByNumberDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.InvoiceNumber))
                throw new ArgumentException("Invoice number is required");

            return await _invoiceSearchRepository.SearchByNumberAsync(dto.InvoiceNumber.Trim());
        }

        public async Task<List<InvoiceSearchResult>> SearchByBarcodeAsync(SearchInvoiceByBarcodeDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Barcode))
                throw new ArgumentException("Barcode is required");

            return await _invoiceSearchRepository.SearchByBarcodeAsync(dto.Barcode.Trim());
        }

        public async Task<List<InvoiceSearchResult>> SearchByCustomerNameAsync(SearchInvoiceByCustomerNameDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CustomerName))
                throw new ArgumentException("Customer name is required");

            return await _invoiceSearchRepository.SearchByCustomerNameAsync(dto.CustomerName.Trim());
        }

        public async Task<List<ReturnableInvoiceDetail>> GetReturnableDetailsAsync(GetReturnableDetailsDTO dto)
        {
            if (dto.InvoiceID <= 0)
                throw new ArgumentException("Invoice is required");

            return await _invoiceSearchRepository.GetReturnableDetailsAsync(dto.InvoiceID);
        }
    }
}