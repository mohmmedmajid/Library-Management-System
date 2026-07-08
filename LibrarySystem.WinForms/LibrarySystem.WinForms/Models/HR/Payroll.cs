using System;

namespace LibrarySystem.WinForms.Models.HR
{
    public class Payroll
    {
        public int PayrollID { get; set; }
        public string PayrollNumber { get; set; } = string.Empty;
        public int PayrollMonth { get; set; }
        public int PayrollYear { get; set; }
        public DateTime PayrollDate { get; set; } = DateTime.Now;
        public int TotalEmployees { get; set; } = 0;
        public decimal TotalBasicSalary { get; set; } = 0;
        public decimal TotalAdditions { get; set; } = 0;
        public decimal TotalDeductions { get; set; } = 0;
        public decimal TotalNetSalary { get; set; } = 0;
        public string Status { get; set; } = "Draft";
        public string ApprovedByName { get; set; } = string.Empty;
        public string PostedByName { get; set; } = string.Empty;
        public string PaidByName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedByName { get; set; } = string.Empty;
    }
}