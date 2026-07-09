namespace API_1.Models
{
    public class SystemSetting
    {
        public int SettingID { get; set; }
        public string SettingKey { get; set; } = string.Empty;
        public string SettingValue { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string DataType { get; set; } = "String";
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
        public int? LastUpdatedBy { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
