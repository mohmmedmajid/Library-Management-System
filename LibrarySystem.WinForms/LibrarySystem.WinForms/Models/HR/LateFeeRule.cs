using System;

namespace LibrarySystem.WinForms.Models.HR
{
    public class LateFeeRule
    {
        public int RuleID { get; set; }
        public string RuleName { get; set; } = string.Empty;
        public string RuleNameAr { get; set; } = string.Empty;
        public decimal FeePerDay { get; set; }
        public int GracePeriodDays { get; set; } = 0;
        public decimal? MaximumFee { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime ApplicableFrom { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
