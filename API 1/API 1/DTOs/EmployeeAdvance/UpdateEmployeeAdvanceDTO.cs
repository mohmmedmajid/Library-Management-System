namespace API_1.DTOs.EmployeeAdvance
{
    public class UpdateEmployeeAdvanceDTO
    {
        public int AdvanceID { get; set; }
        public decimal Amount { get; set; }
        public string? Reason { get; set; }
        public int InstallmentMonths { get; set; }
        public string? Notes { get; set; }
    }
}