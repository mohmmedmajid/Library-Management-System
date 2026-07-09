namespace API_1.DTOs.Payroll
{
    public class CreatePayrollDTO
    {
        public int PayrollMonth { get; set; }
        public int PayrollYear { get; set; }
        public int? CreatedBy { get; set; }
    }
}