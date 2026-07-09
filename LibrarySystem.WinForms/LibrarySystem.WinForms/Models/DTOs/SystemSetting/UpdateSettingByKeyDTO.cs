namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateSettingByKeyDTO
    {
        public string SettingKey { get; set; } = string.Empty;
        public string SettingValue { get; set; } = string.Empty;
        public int LastUpdatedBy { get; set; }
    }
}