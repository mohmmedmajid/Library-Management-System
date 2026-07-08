using System;

namespace LibrarySystem.WinForms.Models.HR
{
    public class EmployeeAdvance
    {
        public int AdvanceID { get; set; }
        public string AdvanceNumber { get; set; } = string.Empty;
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime AdvanceDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int InstallmentMonths { get; set; }
        public decimal MonthlyDeduction { get; set; }
        public decimal PaidAmount { get; set; } = 0;
        public decimal RemainingAmount { get; set; }
        public string Status { get; set; } = "Active";
        public string ApprovedByName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}