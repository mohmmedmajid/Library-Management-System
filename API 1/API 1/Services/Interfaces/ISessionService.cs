using API_1.DTOs.Session;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ISessionService
    {
        Task<(int SessionID, string SessionToken)> CreateAsync(CreateSessionDTO dto);
        Task<bool> UpdateActivityAsync(string sessionToken);
        Task<bool> EndAsync(EndSessionDTO dto);
        Task<bool> EndAllForUserAsync(int userId);
        Task<Session?> GetByTokenAsync(GetSessionByTokenDTO dto);
        Task<List<Session>> GetActiveByUserAsync(int userId);
        Task<List<Session>> GetAllActiveAsync();
        Task<List<Session>> GetHistoryAsync(GetSessionHistoryDTO dto);
        Task<int> CleanInactiveAsync(int inactiveMinutes = 60);
        Task<int> CleanOldAsync(int daysToKeep = 30);
    }
}
