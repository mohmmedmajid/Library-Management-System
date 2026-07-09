namespace API_1.DTOs.Bonus
{
    public class CreateBonusDTO
    {
        public int EmployeeID { get; set; }
        public DateTime BonusDate { get; set; } = DateTime.Now;
        public string BonusType { get; set; } = string.Empty;  
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public int? ApprovedBy { get; set; }
        public string? Notes { get; set; }
        public int? CreatedBy { get; set; }
    }
}