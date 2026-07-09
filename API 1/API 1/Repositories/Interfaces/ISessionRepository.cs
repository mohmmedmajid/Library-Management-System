using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<(int SessionID, string SessionToken)> CreateAsync(Session session);
        Task<bool> UpdateActivityAsync(string sessionToken);
        Task<bool> EndAsync(string sessionToken);
        Task<bool> EndAllForUserAsync(int userId);
        Task<Session?> GetByTokenAsync(string sessionToken);
        Task<List<Session>> GetActiveByUserAsync(int userId);
        Task<List<Session>> GetAllActiveAsync();
        Task<List<Session>> GetHistoryAsync(int? userId = null, DateTime? startDate = null, DateTime? endDate = null, int top = 100);
        Task<int> CleanInactiveAsync(int inactiveMinutes = 60);
        Task<int> CleanOldAsync(int daysToKeep = 30);
    }
}
