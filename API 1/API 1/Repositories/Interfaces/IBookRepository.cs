using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<int> InsertAsync(Book book);
        Task<bool> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int bookId);
        Task<Book?> GetByIdAsync(int bookId);
        Task<Book?> GetByProductIdAsync(int productId);
        Task<List<Book>> GetAllAsync(bool? canBorrow = null);
        Task<List<Book>> SearchAsync(string searchTerm);
    }
}