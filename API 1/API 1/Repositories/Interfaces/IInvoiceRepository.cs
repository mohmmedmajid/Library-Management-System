using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<int> InsertAsync(Invoice invoice);
        Task<bool> UpdateAsync(Invoice invoice);
        Task<bool> DeleteAsync(int invoiceId);
        Task<Invoice?> GetByIdAsync(int invoiceId);
        Task<Invoice?> GetByNumberAsync(string invoiceNumber);
        Task<List<Invoice>> GetAllAsync(int? invoiceTypeId = null, int? customerId = null,
            string? status = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}