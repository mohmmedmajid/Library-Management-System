namespace API_1.Models
{
    public class EmployeeAdvance
    {
        public int AdvanceID { get; set; }
        public string AdvanceNumber { get; set; } = string.Empty;
        public int EmployeeID { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime AdvanceDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public int InstallmentMonths { get; set; }
        public decimal MonthlyDeduction { get; set; }
        public decimal PaidAmount { get; set; } = 0;
        public decimal RemainingAmount { get; set; }
        public string Status { get; set; } = "Active";  
        public int? ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}