using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IInvoiceDetailRepository
    {
        Task<int> InsertAsync(InvoiceDetail invoiceDetail);
        Task<bool> UpdateAsync(InvoiceDetail invoiceDetail);
        Task<bool> DeleteAsync(int invoiceDetailId);
        Task<List<InvoiceDetail>> GetByInvoiceIdAsync(int invoiceId);
        Task<List<InvoiceDetail>> GetAllAsync();

    }
}
