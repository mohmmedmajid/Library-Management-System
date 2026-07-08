using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateJournalEntryDTO
    {
        public int JournalEntryID { get; set; }
        public DateTime EntryDate { get; set; }
        public int CostCenterID { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}