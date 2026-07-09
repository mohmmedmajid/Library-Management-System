using API_1.Models;
using API_1.DTOs.CustomerTransaction;

namespace API_1.Services.Interfaces
{
    public interface ICustomerTransactionService
    {
        Task<int> CreateAsync(CreateCustomerTransactionDTO dto);
        Task<bool> UpdateAsync(UpdateCustomerTransactionDTO dto);
        Task<bool> DeleteAsync(int transactionId);
        Task<CustomerTransaction?> GetByIdAsync(int transactionId);
        Task<List<CustomerTransaction>> GetByCustomerAsync(GetTransactionsByCustomerDTO dto);
        Task<List<CustomerTransaction>> GetAllAsync(GetAllTransactionsDTO dto);
    }
}
