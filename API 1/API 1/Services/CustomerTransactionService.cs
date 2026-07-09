using API_1.DTOs.CustomerTransaction;
using API_1.Models;
using API_1.Repositories;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class CustomerTransactionService : ICustomerTransactionService
    {
        private readonly ICustomerTransactionRepository _customerTransactionRepository;

        public CustomerTransactionService(ICustomerTransactionRepository customerTransactionRepository)
        {   
            _customerTransactionRepository = customerTransactionRepository;
        }

        public async Task<int> CreateAsync(CreateCustomerTransactionDTO dto)
        {
            if (dto.CustomerID <= 0)
                throw new ArgumentException("Invalid customer ID");

            if (string.IsNullOrWhiteSpace(dto.TransactionType))
                throw new ArgumentException("Transaction type is required");

            if (dto.Amount < 0)
                throw new ArgumentException("Amount cannot be negative");

            var validTypes = new[] { "Sale", "Payment", "Borrowing", "Return", "LateFee" };
            if (!validTypes.Contains(dto.TransactionType.Trim()))
                throw new ArgumentException($"Invalid transaction type. Must be one of: {string.Join(", ", validTypes)}");

            var transaction = new CustomerTransaction
            {
                CustomerID = dto.CustomerID,
                TransactionType = dto.TransactionType.Trim(),
                InvoiceID = dto.InvoiceID,
                Amount = dto.Amount,
                Notes = dto.Notes?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _customerTransactionRepository.InsertAsync(transaction);
        }

        public async Task<bool> UpdateAsync(UpdateCustomerTransactionDTO dto)
        {
            if (dto.TransactionID <= 0)
                throw new ArgumentException("Invalid transaction ID");

            if (dto.Amount < 0)
                throw new ArgumentException("Amount cannot be negative");

            var existing = await _customerTransactionRepository.GetByIdAsync(dto.TransactionID);
            if (existing == null)
                throw new InvalidOperationException("Transaction not found");

            var transaction = new CustomerTransaction
            {
                TransactionID = dto.TransactionID,
                Amount = dto.Amount,
                Notes = dto.Notes?.Trim()
            };

            return await _customerTransactionRepository.UpdateAsync(transaction);
        }

        public async Task<bool> DeleteAsync(int transactionId)
        {
            if (transactionId <= 0)
                throw new ArgumentException("Invalid transaction ID");

            var existing = await _customerTransactionRepository.GetByIdAsync(transactionId);
            if (existing == null)
                throw new InvalidOperationException("Transaction not found");

            return await _customerTransactionRepository.DeleteAsync(transactionId);
        }

        public async Task<CustomerTransaction?> GetByIdAsync(int transactionId)
        {
            if (transactionId <= 0)
                throw new ArgumentException("Invalid transaction ID");

            return await _customerTransactionRepository.GetByIdAsync(transactionId);
        }

        public async Task<List<CustomerTransaction>> GetByCustomerAsync(GetTransactionsByCustomerDTO dto)
        {
            if (dto.CustomerID <= 0)
                throw new ArgumentException("Invalid customer ID");

            return await _customerTransactionRepository.GetByCustomerAsync(
                dto.CustomerID,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<CustomerTransaction>> GetAllAsync(GetAllTransactionsDTO dto)
        {
            return await _customerTransactionRepository.GetAllAsync(
                dto.TransactionType,
                dto.StartDate,
                dto.EndDate
            );
        }
    }
}
