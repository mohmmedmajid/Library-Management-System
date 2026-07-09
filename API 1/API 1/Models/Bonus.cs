namespace API_1.Models
{
    public class Bonus
    {
        public int BonusID { get; set; }
        public string BonusNumber { get; set; } = string.Empty;
        public int EmployeeID { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime BonusDate { get; set; } = DateTime.Now;
        public string BonusType { get; set; } = string.Empty; 
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime? PaidDate { get; set; }
        public int? ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}