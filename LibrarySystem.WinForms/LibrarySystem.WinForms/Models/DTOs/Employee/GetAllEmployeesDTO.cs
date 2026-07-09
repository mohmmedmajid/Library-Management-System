namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllEmployeesDTO
    {
        public int DepartmentID { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}