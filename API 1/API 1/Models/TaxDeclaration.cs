namespace API_1.Models
{
    public class TaxDeclaration
    {
        public int DeclarationID { get; set; }
        public string DeclarationNumber { get; set; } = string.Empty;
        public int TaxTypeID { get; set; }
        public string DeclarationType { get; set; } = string.Empty;  
        public int FiscalYear { get; set; }
        public int? FiscalMonth { get; set; }
        public int? FiscalQuarter { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public decimal TotalSalesAmount { get; set; } = 0;
        public decimal TotalPurchaseAmount { get; set; } = 0;
        public decimal TotalSalesTax { get; set; } = 0;
        public decimal TotalPurchaseTax { get; set; } = 0;
        public decimal NetTaxDue { get; set; } = 0;
        public decimal PaidAmount { get; set; } = 0;
        public decimal RemainingAmount { get; set; } = 0;
        public string Status { get; set; } = "Draft";              
        public DateTime? SubmittedDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? PaymentReference { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? TaxCode { get; set; }
        public string? TaxName { get; set; }
        public string? CreatedByName { get; set; }
    }
}
