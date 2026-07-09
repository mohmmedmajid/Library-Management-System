using API_1.DTOs.Customer;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<int> CreateAsync(CreateCustomerDTO dto)
        {
          
            if (string.IsNullOrWhiteSpace(dto.CustomerName))
                throw new ArgumentException("Customer name is required");

            var customer = new Customer
            {
                CustomerName = dto.CustomerName.Trim(),
                Phone = dto.Phone?.Trim(),
                Email = dto.Email?.Trim(),
                Address = dto.Address?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _customerRepository.InsertAsync(customer);
        }

        public async Task<bool> UpdateAsync(UpdateCustomerDTO dto)
        {

            if (string.IsNullOrWhiteSpace(dto.CustomerName))
                throw new ArgumentException("Customer name is required");

            var customer = new Customer
            {
                CustomerID = dto.CustomerID,
                CustomerName = dto.CustomerName.Trim(),
                Phone = dto.Phone?.Trim(),
                Email = dto.Email?.Trim(),
                Address = dto.Address?.Trim(),
                IsActive = dto.IsActive
            };

            return await _customerRepository.UpdateAsync(customer);
        }


        public async Task<bool> DeleteAsync(int customerId)
        {

            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new Exception("Customer not found");

            return await _customerRepository.DeleteAsync(customerId);
        }


        public async Task<Customer?> GetByIdAsync(int customerId)
        {
            return await _customerRepository.GetByIdAsync(customerId);
        }


        public async Task<List<Customer>> GetAllAsync(bool? isActive = null)
        {
            return await _customerRepository.GetAllAsync(isActive);
        }


        public async Task<List<Customer>> SearchAsync(SearchCustomerDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SearchTerm))
                throw new ArgumentException("Search term is required");

            return await _customerRepository.SearchAsync(dto.SearchTerm.Trim());
        }


        public async Task<bool> UpdateTotalsAsync(UpdateCustomerTotalsDTO dto)
        {
            var customer = await _customerRepository.GetByIdAsync(dto.CustomerID);
            if (customer == null)
                throw new Exception("Customer not found");

            return await _customerRepository.UpdateTotalsAsync(
                dto.CustomerID,
                dto.PurchaseAmount,
                dto.DebtAmount,
                dto.LateFeeAmount,
                dto.BorrowingCount
            );
        }
    }
}