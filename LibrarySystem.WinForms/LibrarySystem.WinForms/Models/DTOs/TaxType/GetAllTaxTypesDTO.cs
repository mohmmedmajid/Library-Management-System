namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllTaxTypesDTO
    {
        public string TaxCategory { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}