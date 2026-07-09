using API_1.DTOs.Customer;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<int> CreateAsync(CreateCustomerDTO dto);
        Task<bool> UpdateAsync(UpdateCustomerDTO dto);
        Task<bool> DeleteAsync(int customerId);
        Task<Customer?> GetByIdAsync(int customerId);
        Task<List<Customer>> GetAllAsync(bool? isActive = null);
        Task<List<Customer>> SearchAsync(SearchCustomerDTO dto);
        Task<bool> UpdateTotalsAsync(UpdateCustomerTotalsDTO dto);
    }
}