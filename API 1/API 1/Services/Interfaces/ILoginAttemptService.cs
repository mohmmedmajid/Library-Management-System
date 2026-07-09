using API_1.DTOs.LoginAttempt;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ILoginAttemptService
    {
        Task LogAsync(LogLoginAttemptDTO dto);
        Task<bool> IsAccountLockedAsync(string username, int maxFailedAttempts = 5, int minutesAgo = 30);
        Task<List<LoginAttempt>> GetByUsernameAsync(GetLoginAttemptsByUsernameDTO dto);
        Task<List<LoginAttempt>> GetAllAsync(GetAllLoginAttemptsDTO dto);
        Task<List<LoginAttempt>> GetStatsAsync(GetLoginStatsDTO dto);
        Task<int> CleanOldAsync(int daysToKeep = 90);
    }
}
