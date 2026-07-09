using API_1.DTOs.SupplierTransaction;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ISupplierTransactionService
    {
        Task<int> CreateAsync(CreateSupplierTransactionDTO dto);
        Task<bool> UpdateAsync(UpdateSupplierTransactionDTO dto);
        Task<bool> DeleteAsync(int transactionId);
        Task<SupplierTransaction?> GetByIdAsync(int transactionId);
        Task<List<SupplierTransaction>> GetBySupplierAsync(GetTransactionsBySupplierDTO dto);
        Task<List<SupplierTransaction>> GetAllAsync(GetAllTransactionsDTO dto);
        Task<decimal> GetSupplierBalanceAsync(int supplierId);
        Task<(decimal TotalPurchases, decimal TotalPayments, decimal Balance)> GetSupplierSummaryAsync(int supplierId, DateTime? startDate = null, DateTime? endDate = null);
    }
}