using System;

namespace LibrarySystem.WinForms.Models.Advanced
{
    public class AssetDepreciation
    {
        public int DepreciationID { get; set; }
        public int AssetID { get; set; }
        public string AssetCode { get; set; } = string.Empty;
        public string AssetName { get; set; } = string.Empty;
        public DateTime DepreciationDate { get; set; }
        public string DepreciationPeriod { get; set; } = string.Empty;
        public int FiscalYear { get; set; }
        public int FiscalMonth { get; set; }
        public decimal DepreciationAmount { get; set; }
        public decimal AccumulatedDepreciation { get; set; }
        public decimal BookValue { get; set; }
        public int? JournalEntryID { get; set; }
        public string JournalEntryNumber { get; set; } = string.Empty;
        public string Status { get; set; } = "Draft";
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}