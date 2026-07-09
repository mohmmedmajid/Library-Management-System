namespace API_1.DTOs.JournalEntry
{
    public class UpdateJournalEntryDTO
    {
        public int JournalEntryID { get; set; }
        public DateTime EntryDate { get; set; }
        public int? CostCenterID { get; set; }
        public string? Description { get; set; }
    }
}