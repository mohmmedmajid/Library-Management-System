using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetTransactionsBySupplierDTO
    {
        public int SupplierID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}