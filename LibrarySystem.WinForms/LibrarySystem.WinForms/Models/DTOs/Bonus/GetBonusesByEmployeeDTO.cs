namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetBonusesByEmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string BonusType { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
    }
}