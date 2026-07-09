using API_1.DTOs.LoginAttempt;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class LoginAttemptService : ILoginAttemptService
    {
        private readonly ILoginAttemptRepository _loginAttemptRepository;

        public LoginAttemptService(ILoginAttemptRepository loginAttemptRepository)
        {
            _loginAttemptRepository = loginAttemptRepository;
        }

        public async Task LogAsync(LogLoginAttemptDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new ArgumentException("Username is required");

            var attempt = new LoginAttempt
            {
                Username = dto.Username.Trim(),
                IPAddress = dto.IPAddress?.Trim(),
                IsSuccessful = dto.IsSuccessful,
                FailureReason = dto.FailureReason?.Trim(),
                UserAgent = dto.UserAgent?.Trim(),
                DeviceType = dto.DeviceType?.Trim()
            };

            await _loginAttemptRepository.LogAsync(attempt);
        }

        public async Task<bool> IsAccountLockedAsync(string username, int maxFailedAttempts = 5, int minutesAgo = 30)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is required");

            if (maxFailedAttempts <= 0)
                throw new ArgumentException("Max failed attempts must be greater than zero");

            if (minutesAgo <= 0)
                throw new ArgumentException("Minutes ago must be greater than zero");

            var failedCount = await _loginAttemptRepository.GetRecentFailedCountAsync(
                username.Trim(),
                minutesAgo
            );

            return failedCount >= maxFailedAttempts;
        }

        public async Task<List<LoginAttempt>> GetByUsernameAsync(GetLoginAttemptsByUsernameDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                throw new ArgumentException("Username is required");

            if (dto.StartDate.HasValue && dto.EndDate.HasValue && dto.StartDate > dto.EndDate)
                throw new ArgumentException("Start date must be before end date");

            return await _loginAttemptRepository.GetByUsernameAsync(
                dto.Username.Trim(),
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<LoginAttempt>> GetAllAsync(GetAllLoginAttemptsDTO dto)
        {
            if (dto.StartDate.HasValue && dto.EndDate.HasValue && dto.StartDate > dto.EndDate)
                throw new ArgumentException("Start date must be before end date");

            if (dto.Top <= 0)
                throw new ArgumentException("Top must be greater than zero");

            return await _loginAttemptRepository.GetAllAsync(
                dto.IsSuccessful,
                dto.StartDate,
                dto.EndDate,
                dto.Top
            );
        }

        public async Task<List<LoginAttempt>> GetStatsAsync(GetLoginStatsDTO dto)
        {
            if (dto.StartDate > dto.EndDate)
                throw new ArgumentException("Start date must be before end date");

            return await _loginAttemptRepository.GetStatsAsync(dto.StartDate, dto.EndDate);
        }

        public async Task<int> CleanOldAsync(int daysToKeep = 90)
        {
            if (daysToKeep <= 0)
                throw new ArgumentException("Days to keep must be greater than zero");

            return await _loginAttemptRepository.CleanOldAsync(daysToKeep);
        }
    }
}
