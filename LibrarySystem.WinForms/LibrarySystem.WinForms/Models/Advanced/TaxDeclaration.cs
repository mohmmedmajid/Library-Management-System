// TaxDeclaration.cs
using System;

namespace LibrarySystem.WinForms.Models
{
    public class TaxDeclaration
    {
        public int DeclarationID { get; set; }
        public string DeclarationNumber { get; set; } = string.Empty;
        public int TaxTypeID { get; set; }
        public string TaxCode { get; set; } = string.Empty;
        public string TaxName { get; set; } = string.Empty;
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
        public string PaymentReference { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedByName { get; set; } = string.Empty;
    }
}