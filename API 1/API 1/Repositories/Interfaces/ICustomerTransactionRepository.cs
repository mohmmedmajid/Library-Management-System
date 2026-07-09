using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ICustomerTransactionRepository
    {
        Task<int> InsertAsync(CustomerTransaction transaction);
        Task<bool> UpdateAsync(CustomerTransaction transaction);
        Task<bool> DeleteAsync(int transactionId);
        Task<CustomerTransaction?> GetByIdAsync(int transactionId);
        Task<List<CustomerTransaction>> GetByCustomerAsync(int customerId, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<CustomerTransaction>> GetAllAsync(string? transactionType = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}