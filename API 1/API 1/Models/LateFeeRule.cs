namespace API_1.Models
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
        public DateTime? ApplicableTo { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}