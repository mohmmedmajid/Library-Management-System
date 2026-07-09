using API_1.Data;
using LibrarySystem.WinForms.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories.Interfaces
{
    public class BorrowingDetailRepository(DatabaseHelper dbHelper) : IBorrowingDetailRepository
    {
        private readonly DatabaseHelper _dbHelper = dbHelper;

        public async Task<int> InsertAsync(BorrowingDetail detail)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", detail.BorrowingID),
                new SqlParameter("@ProductID", detail.ProductID),
                new SqlParameter("@Quantity", detail.Quantity),
                new SqlParameter("@PricePerDay", detail.PricePerDay),
                new SqlParameter("@TotalDays", detail.TotalDays),
                new SqlParameter("@TotalPrice", detail.TotalPrice),
                new SqlParameter("@Notes", (object?)detail.Notes ?? DBNull.Value),
                new SqlParameter("@BorrowingDetailID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await _dbHelper.ExecuteNonQueryAsync("SP_BorrowingDetails_Insert", parameters);

            return (int)parameters[7].Value;
        }

        public async Task<bool> UpdateAsync(BorrowingDetail detail)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingDetailID", detail.BorrowingDetailID),
                new SqlParameter("@Quantity", detail.Quantity),
                new SqlParameter("@PricePerDay", detail.PricePerDay),
                new SqlParameter("@TotalDays", detail.TotalDays),
                new SqlParameter("@TotalPrice", detail.TotalPrice),
                new SqlParameter("@Notes", (object?)detail.Notes ?? DBNull.Value)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_BorrowingDetails_Update", parameters);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int detailId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingDetailID", detailId)
            };

            var result = await _dbHelper.ExecuteNonQueryAsync("SP_BorrowingDetails_Delete", parameters);
            return result > 0;
        }

        public async Task<List<BorrowingDetail>> GetByBorrowingIdAsync(int borrowingId)
        {
            var parameters = new[]
            {
                new SqlParameter("@BorrowingID", borrowingId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_BorrowingDetails_GetByBorrowingID", parameters);

            var details = new List<BorrowingDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapToBorrowingDetail(row));
            }

            return details;
        }

        public async Task<BorrowingDetail?> GetByIdAsync(int detailId)
        {
            var all = await GetAllAsync();
            return all.Find(d => d.BorrowingDetailID == detailId);
        }

        public async Task<List<BorrowingDetail>> GetAllAsync()
        {
            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_BorrowingDetails_GetAll", null);

            var details = new List<BorrowingDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(MapToBorrowingDetail(row));
            }

            return details;
        }

        private static BorrowingDetail MapToBorrowingDetail(DataRow row)
        {
            int qty = Convert.ToInt32(row["Quantity"]);
            int returnedQty = row.Table.Columns.Contains("ReturnedQuantity") && row["ReturnedQuantity"] != DBNull.Value
                ? Convert.ToInt32(row["ReturnedQuantity"]) : 0;

            return new BorrowingDetail
            {
                BorrowingDetailID = Convert.ToInt32(row["BorrowingDetailID"]),
                BorrowingID = Convert.ToInt32(row["BorrowingID"]),
                ProductID = Convert.ToInt32(row["ProductID"]),
                Quantity = qty,
                ReturnedQuantity = returnedQty,
                RemainingQuantity = row.Table.Columns.Contains("RemainingQuantity") && row["RemainingQuantity"] != DBNull.Value
                    ? Convert.ToInt32(row["RemainingQuantity"]) : (qty - returnedQty),
                PricePerDay = Convert.ToDecimal(row["PricePerDay"]),
                TotalDays = Convert.ToInt32(row["TotalDays"]),
                TotalPrice = Convert.ToDecimal(row["TotalPrice"]),
                Notes = row["Notes"] == DBNull.Value ? string.Empty : row["Notes"].ToString() ?? string.Empty,

                ProductName = row.Table.Columns.Contains("ProductName") && row["ProductName"] != DBNull.Value
                    ? row["ProductName"].ToString() ?? string.Empty : string.Empty,
                ProductNameAr = row.Table.Columns.Contains("ProductNameAr") && row["ProductNameAr"] != DBNull.Value
                    ? row["ProductNameAr"].ToString() ?? string.Empty : string.Empty,
                BorrowingNumber = row.Table.Columns.Contains("BorrowingNumber") && row["BorrowingNumber"] != DBNull.Value
                    ? row["BorrowingNumber"].ToString() ?? string.Empty : string.Empty
            };
        }
    }
}