using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IBorrowingTransactionRepository
    {
        Task<int> InsertAsync(BorrowingTransaction borrowing);
        Task<bool> UpdateAsync(BorrowingTransaction borrowing);
        Task<bool> DeleteAsync(int borrowingId);
        Task<BorrowingTransaction?> GetByIdAsync(int borrowingId);
        Task<List<BorrowingTransaction>> GetAllAsync(int? customerId = null, string? status = null,
            DateTime? startDate = null, DateTime? endDate = null);
        Task<List<BorrowingTransaction>> GetActiveAsync();
        Task<List<BorrowingTransaction>> GetLateAsync();
        Task<bool> UpdateStatusAsync(int borrowingId, string status);


    }
}
