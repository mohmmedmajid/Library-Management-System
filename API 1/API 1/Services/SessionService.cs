using API_1.DTOs.Session;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<(int SessionID, string SessionToken)> CreateAsync(CreateSessionDTO dto)
        {
            if (dto.UserID <= 0)
                throw new ArgumentException("Invalid user ID");

            var session = new Session
            {
                UserID = dto.UserID,
                IPAddress = dto.IPAddress?.Trim(),
                UserAgent = dto.UserAgent?.Trim(),
                DeviceType = dto.DeviceType?.Trim()
            };

            return await _sessionRepository.CreateAsync(session);
        }

        public async Task<bool> UpdateActivityAsync(string sessionToken)
        {
            if (string.IsNullOrWhiteSpace(sessionToken))
                throw new ArgumentException("Session token is required");

            return await _sessionRepository.UpdateActivityAsync(sessionToken.Trim());
        }

        public async Task<bool> EndAsync(EndSessionDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SessionToken))
                throw new ArgumentException("Session token is required");

            return await _sessionRepository.EndAsync(dto.SessionToken.Trim());
        }

        public async Task<bool> EndAllForUserAsync(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid user ID");

            return await _sessionRepository.EndAllForUserAsync(userId);
        }

        public async Task<Session?> GetByTokenAsync(GetSessionByTokenDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SessionToken))
                throw new ArgumentException("Session token is required");

            return await _sessionRepository.GetByTokenAsync(dto.SessionToken.Trim());
        }

        public async Task<List<Session>> GetActiveByUserAsync(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid user ID");

            return await _sessionRepository.GetActiveByUserAsync(userId);
        }

        public async Task<List<Session>> GetAllActiveAsync()
        {
            return await _sessionRepository.GetAllActiveAsync();
        }

        public async Task<List<Session>> GetHistoryAsync(GetSessionHistoryDTO dto)
        {
            if (dto.StartDate.HasValue && dto.EndDate.HasValue && dto.StartDate > dto.EndDate)
                throw new ArgumentException("Start date must be before end date");

            if (dto.Top <= 0)
                throw new ArgumentException("Top must be greater than zero");

            return await _sessionRepository.GetHistoryAsync(
                dto.UserID,
                dto.StartDate,
                dto.EndDate,
                dto.Top
            );
        }

        public async Task<int> CleanInactiveAsync(int inactiveMinutes = 60)
        {
            if (inactiveMinutes <= 0)
                throw new ArgumentException("Inactive minutes must be greater than zero");

            return await _sessionRepository.CleanInactiveAsync(inactiveMinutes);
        }

        public async Task<int> CleanOldAsync(int daysToKeep = 30)
        {
            if (daysToKeep <= 0)
                throw new ArgumentException("Days to keep must be greater than zero");

            return await _sessionRepository.CleanOldAsync(daysToKeep);
        }
    }
}
