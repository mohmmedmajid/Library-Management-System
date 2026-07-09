namespace API_1.DTOs.LateFeeRule
{
    public class CreateLateFeeRuleDTO
    {
        public string RuleName { get; set; } = string.Empty;
        public string RuleNameAr { get; set; } = string.Empty;
        public decimal FeePerDay { get; set; }
        public int GracePeriodDays { get; set; } = 0;
        public decimal? MaximumFee { get; set; }
        public DateTime ApplicableFrom { get; set; } = DateTime.Now;
        public DateTime? ApplicableTo { get; set; }
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
    }
}