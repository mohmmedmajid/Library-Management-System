namespace API_1.DTOs.SystemSetting
{
    public class UpdateSystemSettingDTO
    {
        public int SettingID { get; set; }
        public string SettingValue { get; set; } = string.Empty;
        public int LastUpdatedBy { get; set; }
    }
}
