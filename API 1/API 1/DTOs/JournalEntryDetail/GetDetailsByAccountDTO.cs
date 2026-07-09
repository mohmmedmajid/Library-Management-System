namespace API_1.DTOs.JournalEntryDetail
{
    public class GetDetailsByAccountDTO
    {
        public int AccountID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}