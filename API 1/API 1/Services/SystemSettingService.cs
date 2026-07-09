using API_1.DTOs.SystemSetting;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class SystemSettingService : ISystemSettingService
    {
        private readonly ISystemSettingRepository _systemSettingRepository;

        public SystemSettingService(ISystemSettingRepository systemSettingRepository)
        {
            _systemSettingRepository = systemSettingRepository;
        }

    
        public async Task<bool> UpdateAsync(UpdateSystemSettingDTO dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.SettingValue))
                throw new ArgumentException("Setting value is required");

           
            var setting = new SystemSetting
            {
                SettingID = dto.SettingID,
                SettingValue = dto.SettingValue.Trim(),
                LastUpdatedBy = dto.LastUpdatedBy
            };

            
            return await _systemSettingRepository.UpdateAsync(setting);
        }

        
        public async Task<bool> UpdateByKeyAsync(UpdateSettingByKeyDTO dto)
        {
          
            if (string.IsNullOrWhiteSpace(dto.SettingKey))
                throw new ArgumentException("Setting key is required");

            if (string.IsNullOrWhiteSpace(dto.SettingValue))
                throw new ArgumentException("Setting value is required");

        
            var existingValue = await _systemSettingRepository.GetByKeyAsync(dto.SettingKey);
            if (existingValue == null)
                throw new Exception("Setting not found");

          
            var allSettings = await _systemSettingRepository.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.SettingKey == dto.SettingKey);

            if (setting == null)
                throw new Exception("Setting not found");

          
            setting.SettingValue = dto.SettingValue.Trim();
            setting.LastUpdatedBy = dto.LastUpdatedBy;

            return await _systemSettingRepository.UpdateAsync(setting);
        }

       
        public async Task<bool> DeleteAsync(int settingId)
        {
           
            var setting = await _systemSettingRepository.GetByIdAsync(settingId);
            if (setting == null)
                throw new Exception("Setting not found");

            return await _systemSettingRepository.DeleteAsync(settingId);
        }

        
        public async Task<SystemSetting?> GetByIdAsync(int settingId)
        {
            return await _systemSettingRepository.GetByIdAsync(settingId);
        }

       
        public async Task<string?> GetByKeyAsync(string settingKey)
        {
           
            if (string.IsNullOrWhiteSpace(settingKey))
                throw new ArgumentException("Setting key is required");

            return await _systemSettingRepository.GetByKeyAsync(settingKey);
        }

        
        public async Task<List<SystemSetting>> GetAllAsync()
        {
            return await _systemSettingRepository.GetAllAsync();
        }
    }
}