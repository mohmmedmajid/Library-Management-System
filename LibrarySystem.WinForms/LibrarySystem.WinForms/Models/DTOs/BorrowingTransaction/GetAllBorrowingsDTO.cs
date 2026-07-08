using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllBorrowingsDTO
    {
        public int CustomerID { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}