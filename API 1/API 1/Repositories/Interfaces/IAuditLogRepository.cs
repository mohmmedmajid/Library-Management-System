using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IAuditLogRepository
    {
        Task InsertAsync(AuditLog auditLog);
        Task<List<AuditLog>> GetByUserAsync(int userId, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<AuditLog>> GetByTableAsync(string tableName, int? recordId = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<AuditLog>> GetAllAsync(string? action = null, DateTime? startDate = null, DateTime? endDate = null, int top = 100);
        Task<int> DeleteOldAsync(int daysToKeep = 90);
    }
}