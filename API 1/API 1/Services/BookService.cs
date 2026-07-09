using API_1.DTOs.Book;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> CreateAsync(CreateBookDTO dto)
        {
            if (dto.ProductID <= 0)
                throw new ArgumentException("Invalid product ID");

            if (dto.BorrowPricePerDay < 0)
                throw new ArgumentException("Borrow price per day cannot be negative");

            if (dto.MaxBorrowDays <= 0)
                throw new ArgumentException("Max borrow days must be greater than zero");

            if (dto.PublicationYear.HasValue && (dto.PublicationYear < 1000 || dto.PublicationYear > DateTime.Now.Year))
                throw new ArgumentException($"Invalid publication year. Must be between 1000 and {DateTime.Now.Year}");

            if (dto.Pages.HasValue && dto.Pages <= 0)
                throw new ArgumentException("Pages must be greater than zero");

            var book = new Book
            {
                ProductID = dto.ProductID,
                ISBN = dto.ISBN?.Trim(),
                Author = dto.Author?.Trim(),
                AuthorAr = dto.AuthorAr?.Trim(),
                Publisher = dto.Publisher?.Trim(),
                PublisherAr = dto.PublisherAr?.Trim(),
                PublicationYear = dto.PublicationYear,
                Language = dto.Language?.Trim(),
                Pages = dto.Pages,
                CanSell = dto.CanSell,
                CanBorrow = dto.CanBorrow,
                BorrowPricePerDay = dto.BorrowPricePerDay,
                MaxBorrowDays = dto.MaxBorrowDays
            };

            return await _bookRepository.InsertAsync(book);
        }

        public async Task<bool> UpdateAsync(UpdateBookDTO dto)
        {
            if (dto.BookID <= 0)
                throw new ArgumentException("Invalid book ID");

            if (dto.BorrowPricePerDay < 0)
                throw new ArgumentException("Borrow price per day cannot be negative");

            if (dto.MaxBorrowDays <= 0)
                throw new ArgumentException("Max borrow days must be greater than zero");

            if (dto.PublicationYear.HasValue && (dto.PublicationYear < 1000 || dto.PublicationYear > DateTime.Now.Year))
                throw new ArgumentException($"Invalid publication year. Must be between 1000 and {DateTime.Now.Year}");

            if (dto.Pages.HasValue && dto.Pages <= 0)
                throw new ArgumentException("Pages must be greater than zero");

            var existing = await _bookRepository.GetByIdAsync(dto.BookID);
            if (existing == null)
                throw new InvalidOperationException("Book not found");

            var book = new Book
            {
                BookID = dto.BookID,
                ISBN = dto.ISBN?.Trim(),
                Author = dto.Author?.Trim(),
                AuthorAr = dto.AuthorAr?.Trim(),
                Publisher = dto.Publisher?.Trim(),
                PublisherAr = dto.PublisherAr?.Trim(),
                PublicationYear = dto.PublicationYear,
                Language = dto.Language?.Trim(),
                Pages = dto.Pages,
                CanSell = dto.CanSell,
                CanBorrow = dto.CanBorrow,
                BorrowPricePerDay = dto.BorrowPricePerDay,
                MaxBorrowDays = dto.MaxBorrowDays
            };

            return await _bookRepository.UpdateAsync(book);
        }

        public async Task<bool> DeleteAsync(int bookId)
        {
            if (bookId <= 0)
                throw new ArgumentException("Invalid book ID");

            var existing = await _bookRepository.GetByIdAsync(bookId);
            if (existing == null)
                throw new InvalidOperationException("Book not found");

            return await _bookRepository.DeleteAsync(bookId);
        }

        public async Task<Book?> GetByIdAsync(int bookId)
        {
            if (bookId <= 0)
                throw new ArgumentException("Invalid book ID");

            return await _bookRepository.GetByIdAsync(bookId);
        }

        public async Task<Book?> GetByProductIdAsync(int productId)
        {
            if (productId <= 0)
                throw new ArgumentException("Invalid product ID");

            return await _bookRepository.GetByProductIdAsync(productId);
        }

        public async Task<List<Book>> GetAllAsync(bool? canBorrow = null)
        {
            return await _bookRepository.GetAllAsync(canBorrow);
        }

        public async Task<List<Book>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("Search term is required");

            if (searchTerm.Trim().Length < 2)
                throw new ArgumentException("Search term must be at least 2 characters");

            return await _bookRepository.SearchAsync(searchTerm.Trim());
        }

        public async Task<bool> ValidateBookAvailabilityAsync(int productId, int quantity)
        {
            if (productId <= 0)
                throw new ArgumentException("Invalid product ID");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            var book = await _bookRepository.GetByProductIdAsync(productId);
            if (book == null)
                return false;

            if (!book.CanBorrow)
                return false;

            if (book.AvailableQuantity.HasValue && book.AvailableQuantity >= quantity)
                return true;

            return false;
        }
    }
}
