using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllSupplierTransactionsDTO
    {
        public string TransactionType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}