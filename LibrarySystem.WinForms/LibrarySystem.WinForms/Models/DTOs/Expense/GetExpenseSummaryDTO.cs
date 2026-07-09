using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetExpenseSummaryDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}