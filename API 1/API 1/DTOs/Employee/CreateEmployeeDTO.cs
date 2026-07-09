namespace API_1.DTOs.Employee
{
    public class CreateEmployeeDTO
    {
        public string EmployeeCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string FullNameAr { get; set; } = string.Empty;
        public string? NationalID { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? DepartmentID { get; set; }
        public string? JobTitle { get; set; }
        public string? JobTitleAr { get; set; }
        public DateTime HireDate { get; set; }
        public decimal BasicSalary { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public int? CreatedBy { get; set; }
    }
}