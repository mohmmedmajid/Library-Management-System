namespace API_1.DTOs.LateFeeRule
{
    public class UpdateLateFeeRuleDTO
    {
        public int RuleID { get; set; }
        public string RuleName { get; set; } = string.Empty;
        public string RuleNameAr { get; set; } = string.Empty;
        public decimal FeePerDay { get; set; }
        public int GracePeriodDays { get; set; }
        public decimal? MaximumFee { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}