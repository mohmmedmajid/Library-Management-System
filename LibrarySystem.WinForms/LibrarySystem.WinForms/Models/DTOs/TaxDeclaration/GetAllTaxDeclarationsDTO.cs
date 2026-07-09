namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllTaxDeclarationsDTO
    {
        public int TaxTypeID { get; set; }
        public string DeclarationType { get; set; } = string.Empty;
        public int FiscalYear { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}