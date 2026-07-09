namespace API_1.DTOs.JournalEntry
{
    public class CreateJournalEntryDTO
    {
        public string JournalEntryNumber { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public string EntryType { get; set; } = string.Empty;  
        public string? ReferenceType { get; set; }
        public int? ReferenceID { get; set; }
        public int? CostCenterID { get; set; }
        public string? Description { get; set; }
        public int? FiscalYear { get; set; }
        public int? FiscalMonth { get; set; }
        public int? CreatedBy { get; set; }
    }
}