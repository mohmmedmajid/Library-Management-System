namespace API_1.DTOs.Bonus
{
    public class UpdateBonusDTO
    {
        public int BonusID { get; set; }
        public DateTime BonusDate { get; set; }
        public string BonusType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        public bool IsPaid { get; set; }
    }
}