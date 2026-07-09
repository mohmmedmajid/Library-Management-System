namespace API_1.DTOs.Book
{
    public class CreateBookDTO
    {
        public int ProductID { get; set; }
        public string? ISBN { get; set; }
        public string? Author { get; set; }
        public string? AuthorAr { get; set; }
        public string? Publisher { get; set; }
        public string? PublisherAr { get; set; }
        public int? PublicationYear { get; set; }
        public string? Language { get; set; }
        public int? Pages { get; set; }
        public bool CanSell { get; set; } = true;
        public bool CanBorrow { get; set; } = true;
        public decimal BorrowPricePerDay { get; set; } = 0;
        public int MaxBorrowDays { get; set; } = 30;
    }
}