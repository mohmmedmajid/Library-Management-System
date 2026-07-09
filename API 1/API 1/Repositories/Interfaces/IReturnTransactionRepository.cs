using API_1.Models;
using LibrarySystem.WinForms.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IReturnTransactionRepository
    {
        Task<int> InsertAsync(ReturnTransaction returnTransaction);
        Task<bool> UpdateAsync(ReturnTransaction returnTransaction);
        Task<bool> DeleteAsync(int returnId);
        Task<ReturnTransaction?> GetByIdAsync(int returnId);
        Task<ReturnTransaction?> GetByBorrowingIdAsync(int borrowingId);
        Task<List<ReturnTransaction>> GetAllAsync(DateTime? startDate = null, DateTime? endDate = null);

        Task<int> InsertDetailAsync(ReturnDetail detail);
        Task<List<ReturnDetail>> GetDetailsByReturnIdAsync(int returnId);
        Task RefreshBorrowingStatusAsync(int borrowingId);
    }
}