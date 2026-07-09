namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateSystemSettingDTO
    {
        public int SettingID { get; set; }
        public string SettingValue { get; set; } = string.Empty;
        public int LastUpdatedBy { get; set; }
    }
}