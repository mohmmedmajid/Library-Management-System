using LibrarySystem.WinForms.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IBorrowingDetailRepository
    {
        Task<int> InsertAsync(BorrowingDetail detail);
        Task<bool> UpdateAsync(BorrowingDetail detail);
        Task<bool> DeleteAsync(int detailId);
        Task<List<BorrowingDetail>> GetByBorrowingIdAsync(int borrowingId);
        Task<List<BorrowingDetail>> GetAllAsync();
        Task<BorrowingDetail?> GetByIdAsync(int detailId); 
    }
}