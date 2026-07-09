namespace API_1.DTOs.TaxDeclaration
{
    public class CreateTaxDeclarationDTO
    {
        public int TaxTypeID { get; set; }
        public string DeclarationType { get; set; } = string.Empty;
        public int FiscalYear { get; set; }
        public int? FiscalMonth { get; set; }
        public int? FiscalQuarter { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
