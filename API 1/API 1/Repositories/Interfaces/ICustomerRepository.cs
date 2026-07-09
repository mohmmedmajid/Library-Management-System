using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> InsertAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(int customerId);
        Task<Customer?> GetByIdAsync(int customerId);
        Task<List<Customer>> GetAllAsync(bool? isActive = null);
        Task<List<Customer>> SearchAsync(string searchTerm);
        Task<bool> UpdateTotalsAsync(int customerId, decimal purchaseAmount, decimal debtAmount, decimal lateFeeAmount, int borrowingCount);
    }
}