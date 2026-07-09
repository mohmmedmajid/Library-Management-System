using API_1.DTOs.BorrowingTransaction;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;
using LibrarySystem.WinForms.Models;


namespace API_1.Services
{
    public class BorrowingTransactionService : IBorrowingTransactionService
    {
        private readonly IBorrowingTransactionRepository _borrowingRepository;
        private readonly IBorrowingDetailRepository _borrowingDetailRepository;
        private readonly ICustomerTransactionRepository _customerTransactionRepository;
        private readonly IBookRepository _bookRepository;

        public BorrowingTransactionService(
            IBorrowingTransactionRepository borrowingRepository,
            IBorrowingDetailRepository borrowingDetailRepository,
            ICustomerTransactionRepository customerTransactionRepository,
            IBookRepository bookRepository)
        {
            _borrowingRepository = borrowingRepository;
            _borrowingDetailRepository = borrowingDetailRepository;
            _customerTransactionRepository = customerTransactionRepository;
            _bookRepository = bookRepository;
        }

        public async Task<int> CreateAsync(CreateBorrowingTransactionDTO dto)
        {
            ValidateBorrowingDTO(dto);

            var borrowing = new BorrowingTransaction
            {
                BorrowingNumber = dto.BorrowingNumber.Trim(),
                CustomerID = dto.CustomerID,
                BorrowingDate = dto.BorrowingDate,
                ExpectedReturnDate = dto.ExpectedReturnDate,
                TotalDays = dto.TotalDays,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount,
                Status = dto.Status.Trim(),
                Notes = dto.Notes?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _borrowingRepository.InsertAsync(borrowing);
        }

        public async Task<int> CreateWithDetailsAsync(CreateBorrowingWithDetailsDTO dto)
        {
            ValidateBorrowingWithDetails(dto);

            await ValidateBooksAvailability(dto.Details);

            var borrowing = new BorrowingTransaction
            {
                BorrowingNumber = dto.BorrowingNumber.Trim(),
                CustomerID = dto.CustomerID,
                BorrowingDate = dto.BorrowingDate,
                ExpectedReturnDate = dto.ExpectedReturnDate,
                TotalDays = dto.TotalDays,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount,
                Status = dto.Status.Trim(),
                Notes = dto.Notes?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            int borrowingId = await _borrowingRepository.InsertAsync(borrowing);

            foreach (var detailDto in dto.Details)
            {
                var detail = new BorrowingDetail
                {
                    BorrowingID = borrowingId,
                    ProductID = detailDto.ProductID,
                    Quantity = detailDto.Quantity,
                    PricePerDay = detailDto.PricePerDay,
                    TotalDays = detailDto.TotalDays,
                    TotalPrice = detailDto.TotalPrice,
                    Notes = dto.Notes?.Trim() ?? null!
                };

                await _borrowingDetailRepository.InsertAsync(detail);
            }

            var transaction = new CustomerTransaction
            {
                CustomerID = dto.CustomerID,
                TransactionType = "Borrowing",
                Amount = dto.TotalAmount,
                Notes = $"Borrowing: {dto.BorrowingNumber}",
                CreatedBy = dto.CreatedBy
            };

            await _customerTransactionRepository.InsertAsync(transaction);

            return borrowingId;
        }

        public async Task<bool> UpdateAsync(UpdateBorrowingTransactionDTO dto)
        {
            if (dto.BorrowingID <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            if (dto.ExpectedReturnDate < DateTime.Now.Date)
                throw new ArgumentException("Expected return date cannot be in the past");

            var existing = await _borrowingRepository.GetByIdAsync(dto.BorrowingID);
            if (existing == null)
                throw new InvalidOperationException("Borrowing transaction not found");

            var validStatuses = new[] { "Borrowed", "Returned", "Late" };
            if (!validStatuses.Contains(dto.Status.Trim()))
                throw new ArgumentException($"Invalid status. Must be one of: {string.Join(", ", validStatuses)}");

            var borrowing = new BorrowingTransaction
            {
                BorrowingID = dto.BorrowingID,
                ExpectedReturnDate = dto.ExpectedReturnDate,
                Status = dto.Status.Trim(),
                Notes = dto.Notes?.Trim()
            };

            return await _borrowingRepository.UpdateAsync(borrowing);
        }

        public async Task<bool> DeleteAsync(int borrowingId)
        {
            if (borrowingId <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            var existing = await _borrowingRepository.GetByIdAsync(borrowingId);
            if (existing == null)
                throw new InvalidOperationException("Borrowing transaction not found");

            if (existing.Status == "Returned")
                throw new InvalidOperationException("Cannot delete a returned borrowing");

            return await _borrowingRepository.DeleteAsync(borrowingId);
        }

        public async Task<BorrowingTransaction?> GetByIdAsync(int borrowingId)
        {
            if (borrowingId <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            return await _borrowingRepository.GetByIdAsync(borrowingId);
        }

        public async Task<List<BorrowingTransaction>> GetAllAsync(GetAllBorrowingsDTO dto)
        {
            return await _borrowingRepository.GetAllAsync(
                dto.CustomerID,
                dto.Status,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<BorrowingTransaction>> GetActiveAsync()
        {
            return await _borrowingRepository.GetActiveAsync();
        }

        public async Task<List<BorrowingTransaction>> GetLateAsync()
        {
            return await _borrowingRepository.GetLateAsync();
        }

        public async Task<bool> UpdateStatusAsync(int borrowingId, string status)
        {
            if (borrowingId <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status is required");

            var validStatuses = new[] { "Borrowed", "Returned", "Late" };
            if (!validStatuses.Contains(status.Trim()))
                throw new ArgumentException($"Invalid status. Must be one of: {string.Join(", ", validStatuses)}");

            return await _borrowingRepository.UpdateStatusAsync(borrowingId, status.Trim());
        }

        public async Task<Dictionary<string, object>> GetBorrowingWithDetailsAsync(int borrowingId)
        {
            if (borrowingId <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            var borrowing = await _borrowingRepository.GetByIdAsync(borrowingId);
            if (borrowing == null)
                throw new InvalidOperationException("Borrowing transaction not found");

            var details = await _borrowingDetailRepository.GetByBorrowingIdAsync(borrowingId);

            return new Dictionary<string, object>
            {
                { "Borrowing", borrowing },
                { "Details", details }
            };
        }

        private void ValidateBorrowingDTO(CreateBorrowingTransactionDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.BorrowingNumber))
                throw new ArgumentException("Borrowing number is required");

            if (dto.CustomerID <= 0)
                throw new ArgumentException("Invalid customer ID");

            if (dto.TotalDays <= 0)
                throw new ArgumentException("Total days must be greater than zero");

            if (dto.TotalAmount < 0)
                throw new ArgumentException("Total amount cannot be negative");

            if (dto.PaidAmount < 0)
                throw new ArgumentException("Paid amount cannot be negative");

            if (dto.PaidAmount > dto.TotalAmount)
                throw new ArgumentException("Paid amount cannot exceed total amount");

            if (dto.ExpectedReturnDate <= dto.BorrowingDate)
                throw new ArgumentException("Expected return date must be after borrowing date");

            int expectedDays = (dto.ExpectedReturnDate - dto.BorrowingDate).Days;
            if (expectedDays != dto.TotalDays)
                throw new ArgumentException($"Total days mismatch. Expected: {expectedDays}, Provided: {dto.TotalDays}");
        }

        private void ValidateBorrowingWithDetails(CreateBorrowingWithDetailsDTO dto)
        {
            ValidateBorrowingDTO(new CreateBorrowingTransactionDTO
            {
                BorrowingNumber = dto.BorrowingNumber,
                CustomerID = dto.CustomerID,
                BorrowingDate = dto.BorrowingDate,
                ExpectedReturnDate = dto.ExpectedReturnDate,
                TotalDays = dto.TotalDays,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount
            });

            if (dto.Details == null || !dto.Details.Any())
                throw new ArgumentException("Borrowing must have at least one detail");

            foreach (var detail in dto.Details)
            {
                if (detail.ProductID <= 0)
                    throw new ArgumentException("Invalid product ID in details");

                if (detail.Quantity <= 0)
                    throw new ArgumentException("Quantity must be greater than zero");

                if (detail.PricePerDay < 0)
                    throw new ArgumentException("Price per day cannot be negative");

                if (detail.TotalDays <= 0)
                    throw new ArgumentException("Total days must be greater than zero");

                if (detail.TotalPrice < 0)
                    throw new ArgumentException("Total price cannot be negative");
            }
        }

        private async Task ValidateBooksAvailability(List<BorrowingDetailItemDTO> details)
        {
            foreach (var detail in details)
            {
                var book = await _bookRepository.GetByProductIdAsync(detail.ProductID);

                if (book == null)
                    throw new InvalidOperationException($"Product {detail.ProductID} is not a book");

                if (!book.CanBorrow)
                    throw new InvalidOperationException($"Book '{book.ProductName}' is not available for borrowing");

                if (book.AvailableQuantity.HasValue && book.AvailableQuantity < detail.Quantity)
                    throw new InvalidOperationException($"Insufficient quantity for book '{book.ProductName}'. Available: {book.AvailableQuantity}, Requested: {detail.Quantity}");
            }
        }

    }
}
