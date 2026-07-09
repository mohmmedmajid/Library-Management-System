using API_1.DTOs.SystemSetting;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ISystemSettingService
    {
        Task<bool> UpdateAsync(UpdateSystemSettingDTO dto);
        Task<bool> UpdateByKeyAsync(UpdateSettingByKeyDTO dto);
        Task<bool> DeleteAsync(int settingId);
        Task<SystemSetting?> GetByIdAsync(int settingId);
        Task<string?> GetByKeyAsync(string settingKey);
        Task<List<SystemSetting>> GetAllAsync();
    }
}