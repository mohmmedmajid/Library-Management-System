namespace API_1.DTOs.Book
{
    public class UpdateBookDTO
    {
        public int BookID { get; set; }
        public string? ISBN { get; set; }
        public string? Author { get; set; }
        public string? AuthorAr { get; set; }
        public string? Publisher { get; set; }
        public string? PublisherAr { get; set; }
        public int? PublicationYear { get; set; }
        public string? Language { get; set; }
        public int? Pages { get; set; }
        public bool CanSell { get; set; }
        public bool CanBorrow { get; set; }
        public decimal BorrowPricePerDay { get; set; }
        public int MaxBorrowDays { get; set; }
    }
}