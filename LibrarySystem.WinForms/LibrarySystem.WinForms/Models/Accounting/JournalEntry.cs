using System;
namespace LibrarySystem.WinForms.Models.Accounting
{
    public class JournalEntry
    {
        public int JournalEntryID { get; set; }
        public string JournalEntryNumber { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public string EntryType { get; set; } = string.Empty;
        public string ReferenceType { get; set; } = string.Empty;
        public int? ReferenceID { get; set; }
        public int? CostCenterID { get; set; }
        public string CostCenterName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TotalDebit { get; set; } = 0;
        public decimal TotalCredit { get; set; } = 0;
        public bool IsBalanced { get; set; } = false;
        public string Status { get; set; } = "Draft";
        public string PostedByName { get; set; } = string.Empty;
        public string CreatedByName { get; set; } = string.Empty;
        public int? FiscalYear { get; set; }
        public int? FiscalMonth { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}