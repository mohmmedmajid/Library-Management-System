namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateDepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string DepartmentCode { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentNameAr { get; set; } = string.Empty;
        public int ManagerID { get; set; }
        public int CostCenterID { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}