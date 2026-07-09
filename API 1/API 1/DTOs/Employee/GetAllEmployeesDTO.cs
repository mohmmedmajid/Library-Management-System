namespace API_1.DTOs.Employee
{
    public class GetAllEmployeesDTO
    {
        public int? DepartmentID { get; set; }
        public string? Status { get; set; }
        public bool? IsActive { get; set; }
    }
}