using System;

namespace LibrarySystem.WinForms.Models.HR
{
    public class EmployeeSalaryComponent
    {
        public int EmployeeSalaryComponentID { get; set; }
        public int EmployeeID { get; set; }
        public int ComponentID { get; set; }
        public string ComponentCode { get; set; } = string.Empty;
        public string ComponentName { get; set; } = string.Empty;
        public string ComponentNameAr { get; set; } = string.Empty;
        public string ComponentType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}