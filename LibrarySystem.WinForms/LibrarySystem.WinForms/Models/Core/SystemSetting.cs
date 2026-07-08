using System;

namespace LibrarySystem.WinForms.Models.Core
{
    public class SystemSetting
    {
        public int SettingID { get; set; }
        public string SettingKey { get; set; } = string.Empty;
        public string SettingValue { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DataType { get; set; } = "String";
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
    }
}