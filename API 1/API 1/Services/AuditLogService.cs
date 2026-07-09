using API_1.DTOs.AuditLog;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }


        public async Task LogAsync(CreateAuditLogDTO dto)
        {

            if (string.IsNullOrWhiteSpace(dto.Action))
                throw new ArgumentException("Action is required");

            var auditLog = new AuditLog
            {
                UserID = dto.UserID,
                Action = dto.Action.Trim(),
                TableName = dto.TableName?.Trim(),
                RecordID = dto.RecordID,
                OldValue = dto.OldValue,
                NewValue = dto.NewValue,
                IPAddress = dto.IPAddress?.Trim()
            };


            await _auditLogRepository.InsertAsync(auditLog);
        }

        public async Task<List<AuditLog>> GetByUserAsync(GetAuditLogByUserDTO dto)
        {

            if (dto.StartDate.HasValue && dto.EndDate.HasValue)
            {
                if (dto.StartDate > dto.EndDate)
                    throw new ArgumentException("Start date cannot be after end date");
            }

            return await _auditLogRepository.GetByUserAsync(
                dto.UserID,
                dto.StartDate,
                dto.EndDate
            );
        }


        public async Task<List<AuditLog>> GetByTableAsync(GetAuditLogByTableDTO dto)
        {

            if (string.IsNullOrWhiteSpace(dto.TableName))
                throw new ArgumentException("Table name is required");

            if (dto.StartDate.HasValue && dto.EndDate.HasValue)
            {
                if (dto.StartDate > dto.EndDate)
                    throw new ArgumentException("Start date cannot be after end date");
            }

            return await _auditLogRepository.GetByTableAsync(
                dto.TableName.Trim(),
                dto.RecordID,
                dto.StartDate,
                dto.EndDate
            );
        }


        public async Task<List<AuditLog>> GetAllAsync(GetAllAuditLogsDTO dto)
        {
           
            if (dto.Top <= 0)
                throw new ArgumentException("Top must be greater than zero");

            if (dto.Top > 1000)
                throw new ArgumentException("Top cannot exceed 1000");

            if (dto.StartDate.HasValue && dto.EndDate.HasValue)
            {
                if (dto.StartDate > dto.EndDate)
                    throw new ArgumentException("Start date cannot be after end date");
            }

            return await _auditLogRepository.GetAllAsync(
                dto.Action,
                dto.StartDate,
                dto.EndDate,
                dto.Top
            );
        }


        public async Task<int> DeleteOldAsync(DeleteOldAuditLogsDTO dto)
        {
            if (dto.DaysToKeep <= 0)
                throw new ArgumentException("Days to keep must be greater than zero");

            if (dto.DaysToKeep < 30)
                throw new ArgumentException("Days to keep must be at least 30 days");

            return await _auditLogRepository.DeleteOldAsync(dto.DaysToKeep);
        }
    }
}