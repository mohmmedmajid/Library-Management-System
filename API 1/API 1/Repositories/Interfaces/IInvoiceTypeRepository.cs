using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IInvoiceTypeRepository
    {
        Task<int> InsertAsync(InvoiceType invoiceType);
        Task<bool> UpdateAsync(InvoiceType invoiceType);
        Task<bool> DeleteAsync(int invoiceTypeId);
        Task<InvoiceType?> GetByIdAsync(int invoiceTypeId);
        Task<List<InvoiceType>> GetAllAsync(bool? isActive = null);
    }
}