namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateSalaryComponentDTO
    {
        public int ComponentID { get; set; }
        public string ComponentCode { get; set; } = string.Empty;
        public string ComponentName { get; set; } = string.Empty;
        public string ComponentNameAr { get; set; } = string.Empty;
        public string ComponentType { get; set; } = string.Empty;
        public bool IsFixed { get; set; }
        public bool IsTaxable { get; set; }
        public decimal DefaultAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}