using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IInvoiceTaxRepository
    {
        Task<int> InsertAsync(InvoiceTax invoiceTax);
        Task<bool> UpdateAsync(InvoiceTax invoiceTax);
        Task<bool> DeleteAsync(int invoiceTaxId);
        Task<InvoiceTax?> GetByIdAsync(int invoiceTaxId);
        Task<List<InvoiceTax>> GetByInvoiceIdAsync(int invoiceId);
        Task<List<InvoiceTax>> GetAllAsync(int? taxTypeId = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<InvoiceTax>> GetSummaryAsync(DateTime startDate, DateTime endDate);
    }
}
