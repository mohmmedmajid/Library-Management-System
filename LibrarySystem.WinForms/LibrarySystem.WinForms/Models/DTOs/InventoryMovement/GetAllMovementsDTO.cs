using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllMovementsDTO
    {
        public string MovementType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}