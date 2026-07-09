using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ISystemSettingRepository
    {
        Task<int> InsertAsync(SystemSetting setting);
        Task<bool> UpdateAsync(SystemSetting setting);
        Task<bool> DeleteAsync(int settingId);
        Task<SystemSetting?> GetByIdAsync(int settingId);
        Task<string?> GetByKeyAsync(string settingKey);
        Task<List<SystemSetting>> GetAllAsync();
    }
}