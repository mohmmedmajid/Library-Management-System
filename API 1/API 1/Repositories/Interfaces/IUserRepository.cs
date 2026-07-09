using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> InsertAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> UpdatePasswordAsync(int userId, string newPasswordHash);
        Task<bool> DeleteAsync(int userId);
        Task<User?> GetByIdAsync(int userId);
        Task<List<User>> GetAllAsync(bool? isActive = null, int? roleId = null);
        Task<User?> LoginAsync(string username, string passwordHash);
        Task FailedLoginAsync(string username);
        Task<bool> UnlockAccountAsync(int userId);
    }
}