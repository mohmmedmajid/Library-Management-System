namespace API_1.Models
{
    public class EmployeeSalaryComponent
    {
        public int EmployeeSalaryComponentID { get; set; }
        public int EmployeeID { get; set; }
        public int ComponentID { get; set; }
        public string? ComponentCode { get; set; }
        public string? ComponentName { get; set; }
        public string? ComponentNameAr { get; set; }
        public string? ComponentType { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
    }
}