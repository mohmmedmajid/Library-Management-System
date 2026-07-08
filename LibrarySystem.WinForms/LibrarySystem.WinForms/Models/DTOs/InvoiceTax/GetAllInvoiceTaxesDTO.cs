using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllInvoiceTaxesDTO
    {
        public int TaxTypeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}