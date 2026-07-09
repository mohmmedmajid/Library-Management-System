using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetUsageByCustomerDTO
    {
        public int CustomerID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}