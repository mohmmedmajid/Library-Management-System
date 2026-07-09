using API_1.DTOs.InvoiceType;
using API_1.Models;
using API_1.Repositories;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class InvoiceTypeService : IInvoiceTypeService
    {
        private readonly IInvoiceTypeRepository _invoiceTypeRepository;

        public InvoiceTypeService(IInvoiceTypeRepository invoiceTypeRepository)
        {
            _invoiceTypeRepository = invoiceTypeRepository;
        }

        public async Task<int> CreateAsync(CreateInvoiceTypeDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TypeName))
                throw new ArgumentException("Type name is required");

            if (string.IsNullOrWhiteSpace(dto.TypeNameAr))
                throw new ArgumentException("Type name in Arabic is required");

            var invoiceType = new InvoiceType
            {
                TypeName = dto.TypeName.Trim(),
                TypeNameAr = dto.TypeNameAr.Trim(),
                Description = dto.Description?.Trim()
            };

            return await _invoiceTypeRepository.InsertAsync(invoiceType);

        }

        public async Task<bool> UpdateAsync(UpdateInvoiceTypeDTO dto)
        {
            if (dto.InvoiceTypeID <= 0)
                throw new ArgumentException("Invalid invoice type ID");

            if (string.IsNullOrWhiteSpace(dto.TypeName))
                throw new ArgumentException("Type name is required");

            if (string.IsNullOrWhiteSpace(dto.TypeNameAr))
                throw new ArgumentException("Type name in Arabic is required");

            var existing = await _invoiceTypeRepository.GetByIdAsync(dto.InvoiceTypeID);
            if (existing == null)
                throw new InvalidOperationException("Invoice type not found");

            var invoiceType = new InvoiceType
            {
                InvoiceTypeID = dto.InvoiceTypeID,
                TypeName = dto.TypeName.Trim(),
                TypeNameAr = dto.TypeNameAr.Trim(),
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _invoiceTypeRepository.UpdateAsync(invoiceType);
        }

        public async Task<bool> DeleteAsync(int invoiceTypeId)
        {
            if (invoiceTypeId <= 0)
                throw new ArgumentException("Invalid invoice type ID");

            var existing = await _invoiceTypeRepository.GetByIdAsync(invoiceTypeId);
            if (existing == null)
                throw new InvalidOperationException("Invoice type not found");

            return await _invoiceTypeRepository.DeleteAsync(invoiceTypeId);
        }

        public async Task<InvoiceType?> GetByIdAsync(int invoiceTypeId)
        {
            if (invoiceTypeId <= 0)
                throw new ArgumentException("Invalid invoice type ID");

            return await _invoiceTypeRepository.GetByIdAsync(invoiceTypeId);
        }

        public async Task<List<InvoiceType>> GetAllAsync(bool? isActive = null)
        {
            return await _invoiceTypeRepository.GetAllAsync(isActive);
        }

    }
}
