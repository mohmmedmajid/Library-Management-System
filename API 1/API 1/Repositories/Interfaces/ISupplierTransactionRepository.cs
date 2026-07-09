using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ISupplierTransactionRepository
    {
        Task<int> InsertAsync(SupplierTransaction transaction);
        Task<bool> UpdateAsync(SupplierTransaction transaction);
        Task<bool> DeleteAsync(int transactionId);
        Task<SupplierTransaction?> GetByIdAsync(int transactionId);
        Task<List<SupplierTransaction>> GetAllAsync(string? transactionType = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<SupplierTransaction>> GetBySupplierAsync(int supplierId, DateTime? startDate = null, DateTime? endDate = null);
        Task<decimal> GetSupplierBalanceAsync(int supplierId);
        Task<List<SupplierTransaction>> GetByInvoiceAsync(int invoiceId);
    }
}