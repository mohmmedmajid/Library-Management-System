using API_1.DTOs.Exchange;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepository _exchangeRepository;

        public ExchangeService(IExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
        }

        public async Task<int> CreateAsync(CreateExchangeDTO dto)
        {
            if (dto.OriginalInvoiceID <= 0 || dto.OriginalInvoiceDetailID <= 0)
                throw new ArgumentException("Original invoice detail is required");

            if (dto.OldQuantity <= 0 || dto.NewQuantity <= 0)
                throw new ArgumentException("Quantities must be greater than zero");

            if (dto.PaymentMethodID <= 0)
                throw new ArgumentException("Payment method is required");

            return await _exchangeRepository.InsertAsync(
                dto.OriginalInvoiceID,
                dto.OriginalInvoiceDetailID,
                dto.CustomerID,
                dto.OldProductID,
                dto.OldQuantity,
                dto.NewProductID,
                dto.NewQuantity,
                dto.PaymentMethodID,
                dto.Notes?.Trim(),
                dto.CreatedBy
            );
        }

        public async Task<ExchangeTransaction?> GetByIdAsync(int exchangeId)
        {
            return await _exchangeRepository.GetByIdAsync(exchangeId);
        }

        public async Task<List<ExchangeTransaction>> GetAllAsync(DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && endDate.HasValue && startDate > endDate)
                throw new ArgumentException("Start date cannot be after end date");

            return await _exchangeRepository.GetAllAsync(null, startDate, endDate);
        }
    }
}