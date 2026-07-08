using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetMovementsByProductDTO
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}