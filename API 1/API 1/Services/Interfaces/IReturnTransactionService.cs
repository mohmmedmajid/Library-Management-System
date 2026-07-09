using API_1.DTOs.ReturnTransaction;
using API_1.Models;
using LibrarySystem.WinForms.Models.DTOs;

namespace API.Application.Services.Interfaces
{
    public interface IReturnTransactionService
    {
        Task<int> CreateAsync(CreateReturnTransactionDTO dto);
        Task<int> CreateWithDetailsAsync(CreateReturnWithDetailsDTO dto);
        Task<bool> UpdateAsync(UpdateReturnTransactionDTO dto);
        Task<bool> DeleteAsync(int returnId);
        Task<ReturnTransaction?> GetByIdAsync(int returnId);
        Task<ReturnTransaction?> GetByBorrowingIdAsync(int borrowingId);
        Task<List<ReturnTransaction>> GetAllAsync(GetAllReturnsDTO dto);
        Task<Dictionary<string, object>> CalculateReturnDetailsAsync(int borrowingId, DateTime returnDate);
    }
}