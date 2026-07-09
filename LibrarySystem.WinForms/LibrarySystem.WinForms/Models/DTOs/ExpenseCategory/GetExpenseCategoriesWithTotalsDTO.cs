using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetExpenseCategoriesWithTotalsDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}