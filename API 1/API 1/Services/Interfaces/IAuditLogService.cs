using API_1.DTOs.AuditLog;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(CreateAuditLogDTO dto);
        Task<List<AuditLog>> GetByUserAsync(GetAuditLogByUserDTO dto);
        Task<List<AuditLog>> GetByTableAsync(GetAuditLogByTableDTO dto);
        Task<List<AuditLog>> GetAllAsync(GetAllAuditLogsDTO dto);
        Task<int> DeleteOldAsync(DeleteOldAuditLogsDTO dto);
    }
}