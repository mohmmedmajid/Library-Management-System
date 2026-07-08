namespace LibrarySystem.WinForms.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentNameAr { get; set; } = string.Empty;
        public int? ManagerID { get; set; }
        public string ManagerName { get; set; } = string.Empty;
        public int? CostCenterID { get; set; }
        public string CostCenterName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int EmployeeCount { get; set; } = 0;
        public System.DateTime CreatedDate { get; set; } = System.DateTime.Now;
    }
}