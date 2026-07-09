namespace API_1.DTOs.EmployeeAdvance
{
    public class CreateEmployeeAdvanceDTO
    {
        public int EmployeeID { get; set; }
        public DateTime AdvanceDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public int InstallmentMonths { get; set; }
        public int? ApprovedBy { get; set; }
        public string? Notes { get; set; }
        public int? CreatedBy { get; set; }
    }
}