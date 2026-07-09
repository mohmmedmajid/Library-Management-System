using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetTopCouponsDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TopCount { get; set; } = 10;
    }
}