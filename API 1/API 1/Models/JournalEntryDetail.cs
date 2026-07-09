namespace API_1.Models
{
    public class JournalEntryDetail
    {
        public int JournalEntryDetailID { get; set; }
        public int JournalEntryID { get; set; }
        public int LineNumber { get; set; }
        public int AccountID { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? AccountNameAr { get; set; }
        public decimal Amount { get; set; }
        public bool IsDebit { get; set; }
        public decimal DebitAmount { get; set; } = 0;
        public decimal CreditAmount { get; set; } = 0;
        public string? Description { get; set; }
    }
}