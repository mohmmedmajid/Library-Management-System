using System;
namespace LibrarySystem.WinForms.Models.HR
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string FullNameAr { get; set; } = string.Empty;
        public string NationalID { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime? HireDate { get; set; }
        public decimal BasicSalary { get; set; }
        public string BankAccountNumber { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        public bool IsActive { get; set; } = true;
        public int YearsOfService { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}