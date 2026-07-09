using API_1.Models;
using API_1.DTOs.InvoiceType;

namespace API_1.Services.Interfaces
{
    public interface IInvoiceTypeService
    {
        Task<int> CreateAsync(CreateInvoiceTypeDTO dto);
        Task<bool> UpdateAsync(UpdateInvoiceTypeDTO dto);
        Task<bool> DeleteAsync(int invoiceTypeId);
        Task<InvoiceType?> GetByIdAsync(int invoiceTypeId);
        Task<List<InvoiceType>> GetAllAsync(bool? isActive = null);
    }
}
