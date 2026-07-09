namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetComponentsByEmployeeDTO
    {
        public int EmployeeID { get; set; }
        public bool IsActive { get; set; } = true;
    }
}