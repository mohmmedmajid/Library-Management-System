namespace API_1.DTOs.Department
{
    public class CreateDepartmentDTO
    {
        public string DepartmentCode { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string DepartmentNameAr { get; set; } = string.Empty;
        public int? ManagerID { get; set; }
        public int? CostCenterID { get; set; }
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
    }
}