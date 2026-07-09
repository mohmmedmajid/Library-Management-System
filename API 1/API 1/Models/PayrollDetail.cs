namespace API_1.Models
{
    public class PayrollDetail
    {
        public int PayrollDetailID { get; set; }
        public int PayrollID { get; set; }
        public int EmployeeID { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public string? Department { get; set; }
        public string? JobTitle { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal TotalAdditions { get; set; } = 0;
        public decimal TotalDeductions { get; set; } = 0;
        public decimal NetSalary { get; set; }
        public string? Notes { get; set; }
    }
}