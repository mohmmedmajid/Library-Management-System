using API_1.DTOs.SupplierTransaction;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class SupplierTransactionService : ISupplierTransactionService
    {
        private readonly ISupplierTransactionRepository _transactionRepository;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierTransactionService(
            ISupplierTransactionRepository transactionRepository,
            ISupplierRepository supplierRepository)
        {
            _transactionRepository = transactionRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<int> CreateAsync(CreateSupplierTransactionDTO dto)
        {
            ValidateTransactionDTO(dto);

            var supplier = await _supplierRepository.GetByIdAsync(dto.SupplierID);
            if (supplier == null)
                throw new InvalidOperationException("Supplier not found");

            ValidateTransactionType(dto.TransactionType);

            if (dto.TransactionType.Trim() == "Purchase")
            {
                var newDebt = supplier.TotalDebt + dto.Amount;
                if (newDebt > supplier.CreditLimit)
                    throw new InvalidOperationException($"This transaction would exceed the supplier's credit limit of {supplier.CreditLimit}");
            }

            var transaction = new SupplierTransaction
            {
                SupplierID = dto.SupplierID,
                TransactionType = dto.TransactionType.Trim(),
                InvoiceID = dto.InvoiceID,
                Amount = dto.Amount,
                ReferenceNumber = dto.ReferenceNumber?.Trim(),
                Notes = dto.Notes?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _transactionRepository.InsertAsync(transaction);
        }

        public async Task<bool> UpdateAsync(UpdateSupplierTransactionDTO dto)
        {
            if (dto.TransactionID <= 0)
                throw new ArgumentException("Invalid transaction ID");

            if (dto.Amount < 0)
                throw new ArgumentException("Amount cannot be negative");

            var existing = await _transactionRepository.GetByIdAsync(dto.TransactionID);
            if (existing == null)
                throw new InvalidOperationException("Transaction not found");

            var transaction = new SupplierTransaction
            {
                TransactionID = dto.TransactionID,
                Amount = dto.Amount,
                ReferenceNumber = dto.ReferenceNumber?.Trim(),
                Notes = dto.Notes?.Trim()
            };

            return await _transactionRepository.UpdateAsync(transaction);
        }

        public async Task<bool> DeleteAsync(int transactionId)
        {
            if (transactionId <= 0)
                throw new ArgumentException("Invalid transaction ID");

            var existing = await _transactionRepository.GetByIdAsync(transactionId);
            if (existing == null)
                throw new InvalidOperationException("Transaction not found");

            return await _transactionRepository.DeleteAsync(transactionId);
        }

        public async Task<SupplierTransaction?> GetByIdAsync(int transactionId)
        {
            if (transactionId <= 0)
                throw new ArgumentException("Invalid transaction ID");

            return await _transactionRepository.GetByIdAsync(transactionId);
        }

        public async Task<List<SupplierTransaction>> GetBySupplierAsync(GetTransactionsBySupplierDTO dto)
        {
            if (dto.SupplierID <= 0)
                throw new ArgumentException("Invalid supplier ID");

            return await _transactionRepository.GetBySupplierAsync(
                dto.SupplierID,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<SupplierTransaction>> GetAllAsync(GetAllTransactionsDTO dto)
        {
            return await _transactionRepository.GetAllAsync(
                dto.TransactionType,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<decimal> GetSupplierBalanceAsync(int supplierId)
        {
            if (supplierId <= 0)
                throw new ArgumentException("Invalid supplier ID");

            var supplier = await _supplierRepository.GetByIdAsync(supplierId);
            if (supplier == null)
                throw new InvalidOperationException("Supplier not found");

            return await _transactionRepository.GetSupplierBalanceAsync(supplierId);
        }

        public async Task<(decimal TotalPurchases, decimal TotalPayments, decimal Balance)> GetSupplierSummaryAsync(
            int supplierId,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            if (supplierId <= 0)
                throw new ArgumentException("Invalid supplier ID");

            var transactions = await _transactionRepository.GetBySupplierAsync(supplierId, startDate, endDate);

            var totalPurchases = transactions
                .Where(t => t.TransactionType == "Purchase")
                .Sum(t => t.Amount);

            var totalPayments = transactions
                .Where(t => t.TransactionType == "Payment")
                .Sum(t => t.Amount);

            var balance = totalPurchases - totalPayments;

            return (totalPurchases, totalPayments, balance);
        }

        private void ValidateTransactionDTO(CreateSupplierTransactionDTO dto)
        {
            if (dto.SupplierID <= 0)
                throw new ArgumentException("Invalid supplier ID");

            if (string.IsNullOrWhiteSpace(dto.TransactionType))
                throw new ArgumentException("Transaction type is required");

            if (dto.Amount < 0)
                throw new ArgumentException("Amount cannot be negative");
        }

        private void ValidateTransactionType(string transactionType)
        {
            var validTypes = new[] { "Purchase", "Payment", "Return", "Debit", "Credit" };
            if (!validTypes.Contains(transactionType.Trim()))
                throw new ArgumentException($"Invalid transaction type. Must be one of: {string.Join(", ", validTypes)}");
        }
    }
}