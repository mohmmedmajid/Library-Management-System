using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllUsageLogsDTO
    {
        public string UsageType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}