using API_1.Models;
using API_1.DTOs.BorrowingDetail;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;
using LibrarySystem.WinForms.Models;

namespace API_1.Services
{
    public class BorrowingDetailService : IBorrowingDetailService
    {
        private readonly IBorrowingDetailRepository _borrowingDetailRepository;
        private readonly IBorrowingTransactionRepository _borrowingRepository;

        public BorrowingDetailService(
            IBorrowingDetailRepository borrowingDetailRepository,
            IBorrowingTransactionRepository borrowingRepository)
        {
            _borrowingDetailRepository = borrowingDetailRepository;
            _borrowingRepository = borrowingRepository;
        }

        public async Task<int> CreateAsync(CreateBorrowingDetailDTO dto)
        {
            if (dto.BorrowingID <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            if (dto.ProductID <= 0)
                throw new ArgumentException("Invalid product ID");

            if (dto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (dto.PricePerDay < 0)
                throw new ArgumentException("Price per day cannot be negative");

            if (dto.TotalDays <= 0)
                throw new ArgumentException("Total days must be greater than zero");

            if (dto.TotalPrice < 0)
                throw new ArgumentException("Total price cannot be negative");

            var borrowing = await _borrowingRepository.GetByIdAsync(dto.BorrowingID);
            if (borrowing == null)
                throw new InvalidOperationException("Borrowing transaction not found");

            var detail = new BorrowingDetail
            {
                BorrowingID = dto.BorrowingID,
                ProductID = dto.ProductID,
                Quantity = dto.Quantity,
                PricePerDay = dto.PricePerDay,
                TotalDays = dto.TotalDays,
                TotalPrice = dto.TotalPrice,
                Notes = dto.Notes?.Trim() ?? null!
            };

            return await _borrowingDetailRepository.InsertAsync(detail);
        }

        public async Task<bool> UpdateAsync(UpdateBorrowingDetailDTO dto)
        {
            if (dto.BorrowingDetailID <= 0)
                throw new ArgumentException("Invalid borrowing detail ID");

            if (dto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (dto.PricePerDay < 0)
                throw new ArgumentException("Price per day cannot be negative");

            if (dto.TotalDays <= 0)
                throw new ArgumentException("Total days must be greater than zero");

            if (dto.TotalPrice < 0)
                throw new ArgumentException("Total price cannot be negative");

            var detail = new BorrowingDetail
            {
                BorrowingDetailID = dto.BorrowingDetailID,
                Quantity = dto.Quantity,
                PricePerDay = dto.PricePerDay,
                TotalDays = dto.TotalDays,
                TotalPrice = dto.TotalPrice,
                Notes = dto.Notes?.Trim() ?? null!
            };

            return await _borrowingDetailRepository.UpdateAsync(detail);
        }

        public async Task<bool> DeleteAsync(int detailId)
        {
            if (detailId <= 0)
                throw new ArgumentException("Invalid borrowing detail ID");

            return await _borrowingDetailRepository.DeleteAsync(detailId);
        }

        public async Task<List<BorrowingDetail>> GetByBorrowingIdAsync(int borrowingId)
        {
            if (borrowingId <= 0)
                throw new ArgumentException("Invalid borrowing ID");

            return await _borrowingDetailRepository.GetByBorrowingIdAsync(borrowingId);
        }

        public async Task<List<BorrowingDetail>> GetAllAsync()
        {
            return await _borrowingDetailRepository.GetAllAsync();
        }

    }
}
