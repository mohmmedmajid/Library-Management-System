namespace API_1.DTOs.TaxDeclaration
{
    public class GetAllTaxDeclarationsDTO
    {
        public int? TaxTypeID { get; set; }
        public string? DeclarationType { get; set; }
        public int? FiscalYear { get; set; }
        public string? Status { get; set; }
    }
}
