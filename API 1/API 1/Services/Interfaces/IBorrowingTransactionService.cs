using API_1.Models;
using API_1.DTOs.BorrowingTransaction;

namespace API_1.Services.Interfaces
{
    public interface IBorrowingTransactionService
    {
        Task<int> CreateAsync(CreateBorrowingTransactionDTO dto);
        Task<int> CreateWithDetailsAsync(CreateBorrowingWithDetailsDTO dto);
        Task<bool> UpdateAsync(UpdateBorrowingTransactionDTO dto);
        Task<bool> DeleteAsync(int borrowingId);
        Task<BorrowingTransaction?> GetByIdAsync(int borrowingId);
        Task<List<BorrowingTransaction>> GetAllAsync(GetAllBorrowingsDTO dto);
        Task<List<BorrowingTransaction>> GetActiveAsync();
        Task<List<BorrowingTransaction>> GetLateAsync();
        Task<bool> UpdateStatusAsync(int borrowingId, string status);
        Task<Dictionary<string, object>> GetBorrowingWithDetailsAsync(int borrowingId);
    }
}
