using API_1.DTOs.LateFee;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class LateFeeService : ILateFeeService
    {
        private readonly ILateFeeRepository _lateFeeRepository;
        private readonly ICustomerTransactionRepository _customerTransactionRepository;

        public LateFeeService(
            ILateFeeRepository lateFeeRepository,
            ICustomerTransactionRepository customerTransactionRepository)
        {
            _lateFeeRepository = lateFeeRepository;
            _customerTransactionRepository = customerTransactionRepository;
        }

        public async Task<int> CreateAsync(CreateLateFeeDTO dto)
        {
            ValidateLateFeeDTO(dto);

            var lateFee = new LateFee
            {
                BorrowingID = dto.BorrowingID,
                CustomerID = dto.CustomerID,
                LateDays = dto.LateDays,
                FeePerDay = dto.FeePerDay,
                TotalFee = dto.TotalFee,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                Status = dto.Status.Trim(),
                Notes = dto.Notes?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _lateFeeRepository.InsertAsync(lateFee);
        }

        public async Task<bool> UpdateAsync(UpdateLateFeeDTO dto)
        {
            if (dto.LateFeeID <= 0)
                throw new ArgumentException("Invalid late fee ID");

            if (dto.PaidAmount < 0)
                throw new ArgumentException("Paid amount cannot be negative");

            if (dto.RemainingAmount < 0)
                throw new ArgumentException("Remaining amount cannot be negative");

            var validStatuses = new[] { "Pending", "Paid", "Waived" };
            if (!validStatuses.Contains(dto.Status.Trim()))
                throw new ArgumentException($"Invalid status. Must be one of: {string.Join(", ", validStatuses)}");

            var existing = await _lateFeeRepository.GetByIdAsync(dto.LateFeeID);
            if (existing == null)
                throw new InvalidOperationException("Late fee not found");

            var lateFee = new LateFee
            {
                LateFeeID = dto.LateFeeID,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                Status = dto.Status.Trim(),
                Notes = dto.Notes?.Trim()
            };

            return await _lateFeeRepository.UpdateAsync(lateFee);
        }

        public async Task<bool> DeleteAsync(int lateFeeId)
        {
            if (lateFeeId <= 0)
                throw new ArgumentException("Invalid late fee ID");

            var existing = await _lateFeeRepository.GetByIdAsync(lateFeeId);
            if (existing == null)
                throw new InvalidOperationException("Late fee not found");

            return await _lateFeeRepository.DeleteAsync(lateFeeId);
        }

        public async Task<LateFee?> GetByIdAsync(int lateFeeId)
        {
            if (lateFeeId <= 0)
                throw new ArgumentException("Invalid late fee ID");

            return await _lateFeeRepository.GetByIdAsync(lateFeeId);
        }

        public async Task<List<LateFee>> GetByCustomerAsync(GetLateFeesByCustomerDTO dto)
        {
            if (dto.CustomerID <= 0)
                throw new ArgumentException("Invalid customer ID");

            return await _lateFeeRepository.GetByCustomerAsync(dto.CustomerID, dto.Status);
        }

        public async Task<List<LateFee>> GetAllAsync(GetAllLateFeesDTO dto)
        {
            return await _lateFeeRepository.GetAllAsync(dto.Status, dto.StartDate, dto.EndDate);
        }

        public async Task<bool> UpdatePaymentAsync(int lateFeeId, decimal paymentAmount)
        {
            if (lateFeeId <= 0)
                throw new ArgumentException("Invalid late fee ID");

            if (paymentAmount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero");

            var lateFee = await _lateFeeRepository.GetByIdAsync(lateFeeId);
            if (lateFee == null)
                throw new InvalidOperationException("Late fee not found");

            if (lateFee.Status == "Paid")
                throw new InvalidOperationException("Late fee is already paid");

            if (lateFee.Status == "Waived")
                throw new InvalidOperationException("Late fee has been waived");

            if (paymentAmount > lateFee.RemainingAmount)
                throw new ArgumentException($"Payment amount ({paymentAmount}) exceeds remaining amount ({lateFee.RemainingAmount})");

    
            bool result = await _lateFeeRepository.UpdatePaymentAsync(lateFeeId, paymentAmount);

            if (result)
            {
                var transaction = new CustomerTransaction
                {
                    CustomerID = lateFee.CustomerID,
                    TransactionType = "Payment",
                    Amount = -paymentAmount, 
                    Notes = $"Late fee payment for borrowing #{lateFee.BorrowingID}",
                    CreatedBy = null
                };

                await _customerTransactionRepository.InsertAsync(transaction);
            }

            return result;
        }

        public async Task<bool> WaiveAsync(int lateFeeId, string? notes)
        {
            if (lateFeeId <= 0)
                throw new ArgumentException("Invalid late fee ID");

            var lateFee = await _lateFeeRepository.GetByIdAsync(lateFeeId);
            if (lateFee == null)
                throw new InvalidOperationException("Late fee not found");

            if (lateFee.Status == "Paid")
                throw new InvalidOperationException("Cannot waive a paid late fee");

            if (lateFee.Status == "Waived")
                throw new InvalidOperationException("Late fee is already waived");

            return await _lateFeeRepository.WaiveAsync(lateFeeId, notes?.Trim());
        }

        private void ValidateLateFeeDTO(CreateLateFeeDTO dto)
        {
            if (dto.BorrowingID <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            if (dto.CustomerID <= 0)
                throw new ArgumentException("Invalid customer ID");

            if (dto.LateDays <= 0)
                throw new ArgumentException("Late days must be greater than zero");

            if (dto.FeePerDay < 0)
                throw new ArgumentException("Fee per day cannot be negative");

            if (dto.TotalFee < 0)
                throw new ArgumentException("Total fee cannot be negative");

            if (dto.PaidAmount < 0)
                throw new ArgumentException("Paid amount cannot be negative");

            if (dto.RemainingAmount < 0)
                throw new ArgumentException("Remaining amount cannot be negative");

            if (dto.PaidAmount > dto.TotalFee)
                throw new ArgumentException("Paid amount cannot exceed total fee");

            decimal calculatedTotal = dto.LateDays * dto.FeePerDay;
            if (Math.Abs(calculatedTotal - dto.TotalFee) > 0.01m)
                throw new ArgumentException($"Total fee calculation mismatch. Expected: {calculatedTotal}, Provided: {dto.TotalFee}");

            decimal calculatedRemaining = dto.TotalFee - dto.PaidAmount;
            if (Math.Abs(calculatedRemaining - dto.RemainingAmount) > 0.01m)
                throw new ArgumentException($"Remaining amount calculation mismatch. Expected: {calculatedRemaining}, Provided: {dto.RemainingAmount}");

            var validStatuses = new[] { "Pending", "Paid", "Waived" };
            if (!validStatuses.Contains(dto.Status.Trim()))
                throw new ArgumentException($"Invalid status. Must be one of: {string.Join(", ", validStatuses)}");
        }
    }
}
