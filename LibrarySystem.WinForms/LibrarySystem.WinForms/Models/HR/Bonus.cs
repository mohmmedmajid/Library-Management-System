using System;

namespace LibrarySystem.WinForms.Models.HR
{
    public class Bonus
    {
        public int BonusID { get; set; }
        public string BonusNumber { get; set; } = string.Empty;
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public DateTime BonusDate { get; set; } = DateTime.Now;
        public string BonusType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public bool IsPaid { get; set; } = false;
        public string ApprovedByName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}