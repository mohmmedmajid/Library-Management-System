using API_1.Models;
using API_1.DTOs.BorrowingDetail;
using LibrarySystem.WinForms.Models;
namespace API_1.Services.Interfaces
{
    public interface IBorrowingDetailService
    {
        Task<int> CreateAsync(CreateBorrowingDetailDTO dto);
        Task<bool> UpdateAsync(UpdateBorrowingDetailDTO dto);
        Task<bool> DeleteAsync(int detailId);
        Task<List<BorrowingDetail>> GetByBorrowingIdAsync(int borrowingId);
        Task<List<BorrowingDetail>> GetAllAsync();
    }
}