namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllDepreciationsDTO
    {
        public int FiscalYear { get; set; }
        public int FiscalMonth { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}