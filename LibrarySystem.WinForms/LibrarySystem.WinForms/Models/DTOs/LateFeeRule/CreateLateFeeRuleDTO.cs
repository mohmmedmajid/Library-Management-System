using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateLateFeeRuleDTO
    {
        public string RuleName { get; set; } = string.Empty;
        public string RuleNameAr { get; set; } = string.Empty;
        public decimal FeePerDay { get; set; }
        public int GracePeriodDays { get; set; } = 0;
        public decimal? MaximumFee { get; set; }
        public DateTime ApplicableFrom { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}