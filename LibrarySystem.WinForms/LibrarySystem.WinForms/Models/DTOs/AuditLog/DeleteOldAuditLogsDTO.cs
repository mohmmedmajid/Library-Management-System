namespace LibrarySystem.WinForms.Models.DTOs
{
    public class DeleteOldAuditLogsDTO
    {
        public int DaysToKeep { get; set; } = 90;
    }
}