namespace API_1.DTOs.SystemSetting
{
    public class UpdateSettingByKeyDTO
    {
        public string SettingKey { get; set; } = string.Empty;
        public string SettingValue { get; set; } = string.Empty;
        public int LastUpdatedBy { get; set; }
    }
}
