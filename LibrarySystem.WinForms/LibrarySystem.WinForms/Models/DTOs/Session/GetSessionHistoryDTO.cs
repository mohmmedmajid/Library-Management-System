using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetSessionHistoryDTO
    {
        public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Top { get; set; } = 100;
    }
}