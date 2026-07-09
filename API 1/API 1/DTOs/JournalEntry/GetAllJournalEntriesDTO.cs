namespace API_1.DTOs.JournalEntry
{
    public class GetAllJournalEntriesDTO
    {
        public string? EntryType { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}