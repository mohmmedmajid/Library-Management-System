namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateSalaryComponentDTO
    {
        public string ComponentCode { get; set; } = string.Empty;
        public string ComponentName { get; set; } = string.Empty;
        public string ComponentNameAr { get; set; } = string.Empty;
        public string ComponentType { get; set; } = string.Empty;
        public bool IsFixed { get; set; } = true;
        public bool IsTaxable { get; set; } = true;
        public decimal DefaultAmount { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}