namespace API_1.Models
{
    public class JournalEntry
    {
        public int JournalEntryID { get; set; }
        public string JournalEntryNumber { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public string EntryType { get; set; } = string.Empty;  
        public string? ReferenceType { get; set; }  
        public int? ReferenceID { get; set; }
        public int? CostCenterID { get; set; }
        public string? CostCenterName { get; set; }
        public string? Description { get; set; }
        public decimal TotalDebit { get; set; } = 0;
        public decimal TotalCredit { get; set; } = 0;
        public bool IsBalanced { get; set; } = false;
        public string Status { get; set; } = "Draft";  
        public DateTime? PostedDate { get; set; }
        public int? PostedBy { get; set; }
        public string? PostedByName { get; set; }
        public DateTime? ReversedDate { get; set; }
        public int? ReversedBy { get; set; }
        public string? ReversedByName { get; set; }
        public int? ReversalEntryID { get; set; }
        public int? FiscalYear { get; set; }
        public int? FiscalMonth { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}