namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateBookDTO
    {
        public int ProductID { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string AuthorAr { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string PublisherAr { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public string Language { get; set; } = string.Empty;
        public int Pages { get; set; }
        public bool CanSell { get; set; } = true;
        public bool CanBorrow { get; set; } = true;
        public decimal BorrowPricePerDay { get; set; } = 0;
        public int MaxBorrowDays { get; set; } = 30;
    }
}