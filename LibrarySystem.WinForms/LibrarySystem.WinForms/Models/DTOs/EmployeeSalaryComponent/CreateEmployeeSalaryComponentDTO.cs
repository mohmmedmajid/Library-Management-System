using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateEmployeeSalaryComponentDTO
    {
        public int EmployeeID { get; set; }
        public int ComponentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; }
    }
}