using API_1.Models;
using API_1.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using API_1.Repositories.Interfaces;

namespace API_1.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public BookRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(Book book)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", book.ProductID),
                new SqlParameter("@ISBN", (object?)book.ISBN ?? DBNull.Value),
                new SqlParameter("@Author", (object?)book.Author ?? DBNull.Value),
                new SqlParameter("@AuthorAr", (object?)book.AuthorAr ?? DBNull.Value),
                new SqlParameter("@Publisher", (object?)book.Publisher ?? DBNull.Value),
                new SqlParameter("@PublisherAr", (object?)book.PublisherAr ?? DBNull.Value),
                new SqlParameter("@PublicationYear", (object?)book.PublicationYear ?? DBNull.Value),
                new SqlParameter("@Language", (object?)book.Language ?? DBNull.Value),
                new SqlParameter("@Pages", (object?)book.Pages ?? DBNull.Value),
                new SqlParameter("@CanSell", book.CanSell),
                new SqlParameter("@CanBorrow", book.CanBorrow),
                new SqlParameter("@BorrowPricePerDay", book.BorrowPricePerDay),
                new SqlParameter("@MaxBorrowDays", book.MaxBorrowDays),
                new SqlParameter("@BookID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            try
            {
                await _dbHelper.ExecuteNonQueryAsync("SP_Books_Insert", parameters);
                return (int)parameters[13].Value;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inserting book: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            var parameters = new[]
            {
                new SqlParameter("@BookID", book.BookID),
                new SqlParameter("@ISBN", (object?)book.ISBN ?? DBNull.Value),
                new SqlParameter("@Author", (object?)book.Author ?? DBNull.Value),
                new SqlParameter("@AuthorAr", (object?)book.AuthorAr ?? DBNull.Value),
                new SqlParameter("@Publisher", (object?)book.Publisher ?? DBNull.Value),
                new SqlParameter("@PublisherAr", (object?)book.PublisherAr ?? DBNull.Value),
                new SqlParameter("@PublicationYear", (object?)book.PublicationYear ?? DBNull.Value),
                new SqlParameter("@Language", (object?)book.Language ?? DBNull.Value),
                new SqlParameter("@Pages", (object?)book.Pages ?? DBNull.Value),
                new SqlParameter("@CanSell", book.CanSell),
                new SqlParameter("@CanBorrow", book.CanBorrow),
                new SqlParameter("@BorrowPricePerDay", book.BorrowPricePerDay),
                new SqlParameter("@MaxBorrowDays", book.MaxBorrowDays)
            };

            try
            {
                var result = await _dbHelper.ExecuteNonQueryAsync("SP_Books_Update", parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error updating book: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int bookId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BookID", bookId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_Books_Delete", parameters);
            return result > 0;
        }

        public async Task<Book?> GetByIdAsync(int bookId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BookID", bookId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Books_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToBook(dataTable.Rows[0]);
        }

        public async Task<Book?> GetByProductIdAsync(int productId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Books_GetByProductID", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToBook(dataTable.Rows[0]);
        }

        public async Task<List<Book>> GetAllAsync(bool? canBorrow = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@CanBorrow", (object?)canBorrow ?? DBNull.Value)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Books_GetAll", parameters);

            var books = new List<Book>();
            foreach (DataRow row in dataTable.Rows)
            {
                books.Add(MapToBook(row));
            }

            return books;
        }

        public async Task<List<Book>> SearchAsync(string searchTerm)
        {
            var parameters = new[]
            {
                new SqlParameter("@SearchTerm", searchTerm)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_Books_Search", parameters);

            var books = new List<Book>();
            foreach (DataRow row in dataTable.Rows)
            {
                books.Add(MapToBook(row));
            }

            return books;
        }

        private Book MapToBook(DataRow row)
        {
            return new Book
            {
                BookID = Convert.ToInt32(row["BookID"]),
                ProductID = Convert.ToInt32(row["ProductID"]),
                ISBN = row.Table.Columns.Contains("ISBN") && row["ISBN"] != DBNull.Value
                    ? row["ISBN"].ToString() : null,
                Author = row.Table.Columns.Contains("Author") && row["Author"] != DBNull.Value
                    ? row["Author"].ToString() : null,
                AuthorAr = row.Table.Columns.Contains("AuthorAr") && row["AuthorAr"] != DBNull.Value
                    ? row["AuthorAr"].ToString() : null,
                Publisher = row.Table.Columns.Contains("Publisher") && row["Publisher"] != DBNull.Value
                    ? row["Publisher"].ToString() : null,
                PublisherAr = row.Table.Columns.Contains("PublisherAr") && row["PublisherAr"] != DBNull.Value
                    ? row["PublisherAr"].ToString() : null,
                PublicationYear = row.Table.Columns.Contains("PublicationYear") && row["PublicationYear"] != DBNull.Value
                    ? Convert.ToInt32(row["PublicationYear"]) : null,
                Language = row.Table.Columns.Contains("Language") && row["Language"] != DBNull.Value
                    ? row["Language"].ToString() : null,
                Pages = row.Table.Columns.Contains("Pages") && row["Pages"] != DBNull.Value
                    ? Convert.ToInt32(row["Pages"]) : null,
                CanSell = row.Table.Columns.Contains("CanSell") && row["CanSell"] != DBNull.Value
                    ? Convert.ToBoolean(row["CanSell"]) : true,
                CanBorrow = row.Table.Columns.Contains("CanBorrow") && row["CanBorrow"] != DBNull.Value
                    ? Convert.ToBoolean(row["CanBorrow"]) : true,
                BorrowPricePerDay = row.Table.Columns.Contains("BorrowPricePerDay") && row["BorrowPricePerDay"] != DBNull.Value
                    ? Convert.ToDecimal(row["BorrowPricePerDay"]) : 0,
                MaxBorrowDays = row.Table.Columns.Contains("MaxBorrowDays") && row["MaxBorrowDays"] != DBNull.Value
                    ? Convert.ToInt32(row["MaxBorrowDays"]) : 30,

                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value
                    ? row["ProductName"].ToString() : null,
                ProductNameAr = row.Table.Columns.Contains("ProductNameAr") && row["ProductNameAr"] != DBNull.Value
                    ? row["ProductNameAr"].ToString() : null,
                Barcode = row.Table.Columns.Contains("Barcode") && row["Barcode"] != DBNull.Value
                    ? row["Barcode"].ToString() : null,
                UnitPrice = row.Table.Columns.Contains("UnitPrice") && row["UnitPrice"] != DBNull.Value
                    ? Convert.ToDecimal(row["UnitPrice"]) : null,
                QuantityInStock = row.Table.Columns.Contains("QuantityInStock") && row["QuantityInStock"] != DBNull.Value
                    ? Convert.ToInt32(row["QuantityInStock"]) : null,
                AvailableQuantity = row.Table.Columns.Contains("AvailableQuantity") && row["AvailableQuantity"] != DBNull.Value
                    ? Convert.ToInt32(row["AvailableQuantity"]) : null
            };
        }
    }
}
