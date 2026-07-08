namespace LibrarySystem.WinForms.Models.HR
{
    public class PayrollDetail
    {
        public int PayrollDetailID { get; set; }
        public int PayrollID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public decimal BasicSalary { get; set; }
        public decimal TotalAdditions { get; set; } = 0;
        public decimal TotalDeductions { get; set; } = 0;
        public decimal NetSalary { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}