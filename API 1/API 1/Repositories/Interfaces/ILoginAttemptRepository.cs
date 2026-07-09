using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ILoginAttemptRepository
    {
        Task LogAsync(LoginAttempt attempt);
        Task<int> GetRecentFailedCountAsync(string username, int minutesAgo = 30);
        Task<List<LoginAttempt>> GetByUsernameAsync(string username, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<LoginAttempt>> GetAllAsync(bool? isSuccessful = null, DateTime? startDate = null, DateTime? endDate = null, int top = 100);
        Task<List<LoginAttempt>> GetStatsAsync(DateTime startDate, DateTime endDate);
        Task<int> CleanOldAsync(int daysToKeep = 90);
    }
}
