using API.Application.Services.Interfaces;
using API_1.DTOs.ReturnTransaction;
using API_1.Models;
using API_1.Repositories.Interfaces;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;

namespace API.Application.Services
{
    public class ReturnTransactionService(
        IReturnTransactionRepository returnRepository,
        IBorrowingTransactionRepository borrowingRepository,
        IBorrowingDetailRepository borrowingDetailRepository,
        ILateFeeRepository lateFeeRepository,
        ICustomerTransactionRepository customerTransactionRepository) : IReturnTransactionService
    {
        private readonly IReturnTransactionRepository _returnRepository = returnRepository;
        private readonly IBorrowingTransactionRepository _borrowingRepository = borrowingRepository;
        private readonly IBorrowingDetailRepository _borrowingDetailRepository = borrowingDetailRepository;
        private readonly ILateFeeRepository _lateFeeRepository = lateFeeRepository;
        private readonly ICustomerTransactionRepository _customerTransactionRepository = customerTransactionRepository;

        public async Task<int> CreateWithDetailsAsync(CreateReturnWithDetailsDTO dto)
        {
            if (dto.BorrowingID <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            if (dto.Details == null || dto.Details.Count == 0)
                throw new ArgumentException("Must select at least one book to return");

            var borrowing = await _borrowingRepository.GetByIdAsync(dto.BorrowingID) ??
                throw new InvalidOperationException("Borrowing transaction not found");

            var allDetails = await _borrowingDetailRepository.GetByBorrowingIdAsync(dto.BorrowingID);

            decimal totalLateFee = 0;
            decimal totalRefund = 0;
            int maxLateDays = 0;

            foreach (var item in dto.Details)
            {
                if (item.ReturnQuantity <= 0)
                    throw new ArgumentException("Return quantity must be greater than zero");

                var borrowingDetail = allDetails.Find(d => d.BorrowingDetailID == item.BorrowingDetailID) ??
                    throw new ArgumentException($"Borrowing detail {item.BorrowingDetailID} does not belong to this borrowing");

                int remaining = borrowingDetail.Quantity - borrowingDetail.ReturnedQuantity;
                if (item.ReturnQuantity > remaining)
                    throw new ArgumentException($"Cannot return {item.ReturnQuantity} of '{borrowingDetail.ProductName}'. Remaining: {remaining}");

                if (item.LateFeeAmount < 0 || item.RefundAmount < 0)
                    throw new ArgumentException("Amounts cannot be negative");

                if (item.LateFeeAmount > 0 && item.RefundAmount > 0)
                    throw new ArgumentException("Cannot have both late fee and refund on the same line");

                totalLateFee += item.LateFeeAmount;
                totalRefund += item.RefundAmount;
                maxLateDays = Math.Max(maxLateDays, item.LateDays);
            }

            int totalActualDays = Math.Max(1, (dto.ReturnDate.Date - borrowing.BorrowingDate.Date).Days);

            var header = new ReturnTransaction
            {
                BorrowingID = dto.BorrowingID,
                ReturnDate = dto.ReturnDate,
                ActualDaysUsed = totalActualDays,
                LateDays = maxLateDays,
                LateFeeAmount = totalLateFee,
                RefundAmount = totalRefund,
                Notes = dto.Notes?.Trim() ?? string.Empty,
                CreatedBy = dto.CreatedBy
            };

            int returnId = await _returnRepository.InsertAsync(header);

            foreach (var item in dto.Details)
            {
                var returnDetail = new ReturnDetail
                {
                    ReturnID = returnId,
                    BorrowingDetailID = item.BorrowingDetailID,
                    ProductID = item.ProductID,
                    ReturnQuantity = item.ReturnQuantity,
                    LateDays = item.LateDays,
                    LateFeeAmount = item.LateFeeAmount,
                    RefundAmount = item.RefundAmount,
                    Notes = item.Notes?.Trim() ?? string.Empty
                };

                await _returnRepository.InsertDetailAsync(returnDetail);
            }

            await _returnRepository.RefreshBorrowingStatusAsync(dto.BorrowingID);

            if (totalLateFee > 0)
            {
                var lateFee = new LateFee
                {
                    BorrowingID = dto.BorrowingID,
                    CustomerID = borrowing.CustomerID,
                    LateDays = maxLateDays,
                    FeePerDay = maxLateDays > 0 ? totalLateFee / maxLateDays : 0,
                    TotalFee = totalLateFee,
                    PaidAmount = 0,
                    RemainingAmount = totalLateFee,
                    Status = "Pending",
                    Notes = "Late fee (partial/full return)",
                    CreatedBy = dto.CreatedBy
                };

                await _lateFeeRepository.InsertAsync(lateFee);

                await _customerTransactionRepository.InsertAsync(new CustomerTransaction
                {
                    CustomerID = borrowing.CustomerID,
                    TransactionType = "LateFee",
                    Amount = totalLateFee,
                    Notes = $"Late fee for borrowing: {borrowing.BorrowingNumber}",
                    CreatedBy = dto.CreatedBy
                });
            }

            // 5) استرجاع مبلغ إن وجد
            if (totalRefund > 0)
            {
                await _customerTransactionRepository.InsertAsync(new CustomerTransaction
                {
                    CustomerID = borrowing.CustomerID,
                    TransactionType = "Return",
                    Amount = -totalRefund,
                    Notes = $"Refund for early return: {borrowing.BorrowingNumber}",
                    CreatedBy = dto.CreatedBy
                });
            }

            return returnId;
        }

        public async Task<int> CreateAsync(CreateReturnTransactionDTO dto)
        {
            ValidateReturnDTO(dto);

            var borrowing = await _borrowingRepository.GetByIdAsync(dto.BorrowingID) ??
                throw new InvalidOperationException("Borrowing transaction not found");

            var returnTransaction = new ReturnTransaction
            {
                BorrowingID = dto.BorrowingID,
                ReturnDate = dto.ReturnDate,
                ActualDaysUsed = dto.ActualDaysUsed,
                LateDays = dto.LateDays,
                LateFeeAmount = dto.LateFeeAmount,
                RefundAmount = dto.RefundAmount,
                Notes = dto.Notes?.Trim() ?? string.Empty,
                CreatedBy = dto.CreatedBy
            };

            int returnId = await _returnRepository.InsertAsync(returnTransaction);

            if (dto.LateDays > 0 && dto.LateFeeAmount > 0)
            {
                var lateFee = new LateFee
                {
                    BorrowingID = dto.BorrowingID,
                    CustomerID = borrowing.CustomerID,
                    LateDays = dto.LateDays,
                    FeePerDay = dto.LateFeeAmount / dto.LateDays,
                    TotalFee = dto.LateFeeAmount,
                    PaidAmount = 0,
                    RemainingAmount = dto.LateFeeAmount,
                    Status = "Pending",
                    Notes = "Late return fee",
                    CreatedBy = dto.CreatedBy
                };

                await _lateFeeRepository.InsertAsync(lateFee);

                var transaction = new CustomerTransaction
                {
                    CustomerID = borrowing.CustomerID,
                    TransactionType = "LateFee",
                    Amount = dto.LateFeeAmount,
                    Notes = $"Late fee for borrowing: {borrowing.BorrowingNumber}",
                    CreatedBy = dto.CreatedBy
                };

                await _customerTransactionRepository.InsertAsync(transaction);
            }

            if (dto.RefundAmount > 0)
            {
                var refundTransaction = new CustomerTransaction
                {
                    CustomerID = borrowing.CustomerID,
                    TransactionType = "Return",
                    Amount = -dto.RefundAmount,
                    Notes = $"Refund for early return: {borrowing.BorrowingNumber}",
                    CreatedBy = dto.CreatedBy
                };

                await _customerTransactionRepository.InsertAsync(refundTransaction);
            }

            await _returnRepository.RefreshBorrowingStatusAsync(dto.BorrowingID);

            return returnId;
        }

        public async Task<bool> UpdateAsync(UpdateReturnTransactionDTO dto)
        {
            if (dto.ReturnID <= 0)
                throw new ArgumentException("Invalid return ID");

            if (dto.ActualDaysUsed < 0)
                throw new ArgumentException("Actual days used cannot be negative");

            if (dto.LateDays < 0)
                throw new ArgumentException("Late days cannot be negative");

            if (dto.LateFeeAmount < 0)
                throw new ArgumentException("Late fee amount cannot be negative");

            if (dto.RefundAmount < 0)
                throw new ArgumentException("Refund amount cannot be negative");

            _ = await _returnRepository.GetByIdAsync(dto.ReturnID) ??
                throw new InvalidOperationException("Return transaction not found");

            var returnTransaction = new ReturnTransaction
            {
                ReturnID = dto.ReturnID,
                ReturnDate = dto.ReturnDate,
                ActualDaysUsed = dto.ActualDaysUsed,
                LateDays = dto.LateDays,
                LateFeeAmount = dto.LateFeeAmount,
                RefundAmount = dto.RefundAmount,
                Notes = dto.Notes?.Trim() ?? string.Empty
            };

            return await _returnRepository.UpdateAsync(returnTransaction);
        }

        public async Task<bool> DeleteAsync(int returnId)
        {
            if (returnId <= 0)
                throw new ArgumentException("Invalid return ID");

            _ = await _returnRepository.GetByIdAsync(returnId) ??
                throw new InvalidOperationException("Return transaction not found");

            return await _returnRepository.DeleteAsync(returnId);
        }

        public async Task<ReturnTransaction?> GetByIdAsync(int returnId)
        {
            if (returnId <= 0)
                throw new ArgumentException("Invalid return ID");

            return await _returnRepository.GetByIdAsync(returnId);
        }

        public async Task<ReturnTransaction?> GetByBorrowingIdAsync(int borrowingId)
        {
            if (borrowingId <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            return await _returnRepository.GetByBorrowingIdAsync(borrowingId);
        }

        public async Task<List<ReturnTransaction>> GetAllAsync(GetAllReturnsDTO dto)
        {
            return await _returnRepository.GetAllAsync(dto.StartDate, dto.EndDate);
        }

        public async Task<Dictionary<string, object>> CalculateReturnDetailsAsync(int borrowingId, DateTime returnDate)
        {
            if (borrowingId <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            var borrowing = await _borrowingRepository.GetByIdAsync(borrowingId) ??
                throw new InvalidOperationException("Borrowing transaction not found");

            int actualDaysUsed = (returnDate.Date - borrowing.BorrowingDate.Date).Days;
            if (actualDaysUsed < 0)
                actualDaysUsed = 0;

            int lateDays = 0;
            if (returnDate.Date > borrowing.ExpectedReturnDate.Date)
            {
                lateDays = (returnDate.Date - borrowing.ExpectedReturnDate.Date).Days;
            }

            decimal lateFeePerDay = 0.5m;
            decimal lateFeeAmount = lateDays * lateFeePerDay;

            decimal refundAmount = 0;
            if (returnDate.Date < borrowing.ExpectedReturnDate.Date)
            {
                int unusedDays = (borrowing.ExpectedReturnDate.Date - returnDate.Date).Days;
                decimal pricePerDay = borrowing.TotalAmount / borrowing.TotalDays;
                refundAmount = unusedDays * pricePerDay;
            }

            return new Dictionary<string, object>
            {
                { "BorrowingID", borrowingId },
                { "BorrowingNumber", borrowing.BorrowingNumber },
                { "BorrowingDate", borrowing.BorrowingDate },
                { "ExpectedReturnDate", borrowing.ExpectedReturnDate },
                { "ReturnDate", returnDate },
                { "TotalDays", borrowing.TotalDays },
                { "ActualDaysUsed", actualDaysUsed },
                { "LateDays", lateDays },
                { "LateFeeAmount", lateFeeAmount },
                { "RefundAmount", refundAmount },
                { "OriginalAmount", borrowing.TotalAmount }
            };
        }

        private static void ValidateReturnDTO(CreateReturnTransactionDTO dto)
        {
            if (dto.BorrowingID <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            if (dto.ActualDaysUsed < 0)
                throw new ArgumentException("Actual days used cannot be negative");

            if (dto.LateDays < 0)
                throw new ArgumentException("Late days cannot be negative");

            if (dto.LateFeeAmount < 0)
                throw new ArgumentException("Late fee amount cannot be negative");

            if (dto.RefundAmount < 0)
                throw new ArgumentException("Refund amount cannot be negative");

            if (dto.LateFeeAmount > 0 && dto.RefundAmount > 0)
                throw new ArgumentException("Cannot have both late fee and refund");
        }
    }
}