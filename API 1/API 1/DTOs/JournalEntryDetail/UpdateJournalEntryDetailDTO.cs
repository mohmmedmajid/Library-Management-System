namespace API_1.DTOs.JournalEntryDetail
{
    public class UpdateJournalEntryDetailDTO
    {
        public int JournalEntryDetailID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public bool IsDebit { get; set; }
        public string? Description { get; set; }
    }
}