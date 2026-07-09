using API_1.Models;
using API_1.DTOs.Book;

namespace API_1.Services.Interfaces
{
    public interface IBookService
    {
        Task<int> CreateAsync(CreateBookDTO dto);
        Task<bool> UpdateAsync(UpdateBookDTO dto);
        Task<bool> DeleteAsync(int bookId);
        Task<Book?> GetByIdAsync(int bookId);
        Task<Book?> GetByProductIdAsync(int productId);
        Task<List<Book>> GetAllAsync(bool? canBorrow = null);
        Task<List<Book>> SearchAsync(string searchTerm);
        Task<bool> ValidateBookAvailabilityAsync(int productId, int quantity);
    }
}
