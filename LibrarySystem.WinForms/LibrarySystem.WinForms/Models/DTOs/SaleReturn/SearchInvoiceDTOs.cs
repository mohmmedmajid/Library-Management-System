// Models/DTOs/SearchInvoiceDTOs.cs
namespace LibrarySystem.WinForms.Models.DTOs
{
    public class SearchInvoiceByNumberDTO
    {
        public string InvoiceNumber { get; set; } = string.Empty;
    }

    public class SearchInvoiceByBarcodeDTO
    {
        public string Barcode { get; set; } = string.Empty;
    }

    public class SearchInvoiceByCustomerNameDTO
    {
        public string CustomerName { get; set; } = string.Empty;
    }

    public class GetReturnableDetailsDTO
    {
        public int InvoiceID { get; set; }
    }
}