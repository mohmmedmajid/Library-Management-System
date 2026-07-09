using API_1.DTOs.InvoiceDetail;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceDetailService(
            IInvoiceDetailRepository invoiceDetailRepository,
            IInvoiceRepository invoiceRepository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<int> CreateAsync(CreateInvoiceDetailDTO dto)
        {
            if (dto.InvoiceID <= 0)
                throw new ArgumentException("Invalid invoice ID");

            if (dto.ProductID <= 0)
                throw new ArgumentException("Invalid product ID");

            if (dto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (dto.UnitPrice < 0)
                throw new ArgumentException("Unit price cannot be negative");

            if (dto.TotalPrice < 0)
                throw new ArgumentException("Total price cannot be negative");

            var invoice = await _invoiceRepository.GetByIdAsync(dto.InvoiceID);
            if (invoice == null)
                throw new InvalidOperationException("Invoice not found");

            var detail = new InvoiceDetail
            {
                InvoiceID = dto.InvoiceID,
                ProductID = dto.ProductID,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                DiscountAmount = dto.DiscountAmount,
                DiscountPercent = dto.DiscountPercent,
                TotalPrice = dto.TotalPrice,
                Notes = dto.Notes?.Trim()
            };

            return await _invoiceDetailRepository.InsertAsync(detail);
        }

        public async Task<bool> UpdateAsync(UpdateInvoiceDetailDTO dto)
        {
            if (dto.InvoiceDetailID <= 0)
                throw new ArgumentException("Invalid invoice detail ID");

            if (dto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (dto.UnitPrice < 0)
                throw new ArgumentException("Unit price cannot be negative");

            if (dto.TotalPrice < 0)
                throw new ArgumentException("Total price cannot be negative");

            var detail = new InvoiceDetail
            {
                InvoiceDetailID = dto.InvoiceDetailID,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                DiscountAmount = dto.DiscountAmount,
                DiscountPercent = dto.DiscountPercent,
                TotalPrice = dto.TotalPrice,
                Notes = dto.Notes?.Trim()
            };

            return await _invoiceDetailRepository.UpdateAsync(detail);
        }

        public async Task<bool> DeleteAsync(int invoiceDetailId)
        {
            if (invoiceDetailId <= 0)
                throw new ArgumentException("Invalid invoice detail ID");

            return await _invoiceDetailRepository.DeleteAsync(invoiceDetailId);
        }

        public async Task<List<InvoiceDetail>> GetByInvoiceIdAsync(int invoiceId)
        {
            if (invoiceId <= 0)
                throw new ArgumentException("Invalid invoice ID");

            return await _invoiceDetailRepository.GetByInvoiceIdAsync(invoiceId);
        }

        public async Task<List<InvoiceDetail>> GetAllAsync()
        {
            return await _invoiceDetailRepository.GetAllAsync();
        }
    }
}

