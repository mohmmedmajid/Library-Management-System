using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetCommissionsBySalesRepDTO
    {
        public int SalesRepID { get; set; }
        public bool IsPaid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}