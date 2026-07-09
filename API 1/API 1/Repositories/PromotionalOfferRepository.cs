using API_1.Data;
using API_1.Models;
using API_1.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_1.Repositories
{
    public class PromotionalOfferRepository : IPromotionalOfferRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public PromotionalOfferRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> InsertAsync(PromotionalOffer offer)
        {
            var parameters = new[]
            {
                new SqlParameter("@OfferName", offer.OfferName),
                new SqlParameter("@OfferNameAr", offer.OfferNameAr),
                new SqlParameter("@OfferType", offer.OfferType),
                new SqlParameter("@BuyQuantity", (object?)offer.BuyQuantity ?? DBNull.Value),
                new SqlParameter("@GetQuantity", (object?)offer.GetQuantity ?? DBNull.Value),
                new SqlParameter("@BuyProductID", (object?)offer.BuyProductID ?? DBNull.Value),
                new SqlParameter("@GetProductID", (object?)offer.GetProductID ?? DBNull.Value),
                new SqlParameter("@DiscountPercent", (object?)offer.DiscountPercent ?? DBNull.Value),
                new SqlParameter("@BundlePrice", (object?)offer.BundlePrice ?? DBNull.Value),
                new SqlParameter("@ApplicableOn", offer.ApplicableOn),
                new SqlParameter("@CategoryID", (object?)offer.CategoryID ?? DBNull.Value),
                new SqlParameter("@StartDate", offer.StartDate),
                new SqlParameter("@EndDate", offer.EndDate),
                new SqlParameter("@Priority", offer.Priority),
                new SqlParameter("@Description", (object?)offer.Description ?? DBNull.Value),
                new SqlParameter("@CreatedBy", (object?)offer.CreatedBy ?? DBNull.Value),
                new SqlParameter("@OfferID", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_PromotionalOffers_Insert", parameters));

            return (int)parameters[16].Value;
        }

        public async Task<bool> UpdateAsync(PromotionalOffer offer)
        {
            var parameters = new[]
            {
                new SqlParameter("@OfferID", offer.OfferID),
                new SqlParameter("@OfferName", offer.OfferName),
                new SqlParameter("@OfferNameAr", offer.OfferNameAr),
                new SqlParameter("@OfferType", offer.OfferType),
                new SqlParameter("@BuyQuantity", (object?)offer.BuyQuantity ?? DBNull.Value),
                new SqlParameter("@GetQuantity", (object?)offer.GetQuantity ?? DBNull.Value),
                new SqlParameter("@DiscountPercent", (object?)offer.DiscountPercent ?? DBNull.Value),
                new SqlParameter("@BundlePrice", (object?)offer.BundlePrice ?? DBNull.Value),
                new SqlParameter("@StartDate", offer.StartDate),
                new SqlParameter("@EndDate", offer.EndDate),
                new SqlParameter("@Priority", offer.Priority),
                new SqlParameter("@Description", (object?)offer.Description ?? DBNull.Value),
                new SqlParameter("@IsActive", offer.IsActive)
            };

            var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_PromotionalOffers_Update", parameters));
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int offerId)
        {
            var parameters = new[]
            {
                new SqlParameter("@OfferID", offerId)
            };

            try
            {
                var result = await Task.Run(() => _dbHelper.ExecuteNonQuery("SP_PromotionalOffers_Delete", parameters));
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PromotionalOffer?> GetByIdAsync(int offerId)
        {
            var parameters = new[]
            {
                new SqlParameter("@OfferID", offerId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_PromotionalOffers_GetById", parameters);

            if (dataTable.Rows.Count == 0)
                return null;

            return MapToPromotionalOffer(dataTable.Rows[0]);
        }

        public async Task<List<PromotionalOffer>> GetAllAsync(bool? isActive = null, bool currentOnly = false)
        {
            var parameters = new[]
            {
                new SqlParameter("@IsActive", (object?)isActive ?? DBNull.Value),
                new SqlParameter("@CurrentOnly", currentOnly)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_PromotionalOffers_GetAll", parameters);

            var offers = new List<PromotionalOffer>();
            foreach (DataRow row in dataTable.Rows)
            {
                offers.Add(MapToPromotionalOffer(row));
            }

            return offers;
        }

        public async Task<List<PromotionalOffer>> GetActiveOffersForProductAsync(int productId, int categoryId)
        {
            var parameters = new[]
            {
                new SqlParameter("@ProductID", productId),
                new SqlParameter("@CategoryID", categoryId)
            };

            var dataTable = await _dbHelper.ExecuteReaderAsync("SP_PromotionalOffers_GetActiveForProduct", parameters);

            var offers = new List<PromotionalOffer>();
            foreach (DataRow row in dataTable.Rows)
            {
                offers.Add(MapToPromotionalOffer(row));
            }

            return offers;
        }

        private PromotionalOffer MapToPromotionalOffer(DataRow row)
        {
            return new PromotionalOffer
            {
                OfferID = Convert.ToInt32(row["OfferID"]),
                OfferName = row["OfferName"].ToString() ?? string.Empty,
                OfferNameAr = row["OfferNameAr"].ToString() ?? string.Empty,
                OfferType = row.Table.Columns.Contains("OfferType") && row["OfferType"] != DBNull.Value
                    ? row["OfferType"].ToString() ?? string.Empty : string.Empty,
                BuyQuantity = row.Table.Columns.Contains("BuyQuantity") && row["BuyQuantity"] != DBNull.Value
                    ? Convert.ToInt32(row["BuyQuantity"]) : null,
                GetQuantity = row.Table.Columns.Contains("GetQuantity") && row["GetQuantity"] != DBNull.Value
                    ? Convert.ToInt32(row["GetQuantity"]) : null,
                BuyProductID = row.Table.Columns.Contains("BuyProductID") && row["BuyProductID"] != DBNull.Value
                    ? Convert.ToInt32(row["BuyProductID"]) : null,
                BuyProductName = row.Table.Columns.Contains("BuyProductName") && row["BuyProductName"] != DBNull.Value
                    ? row["BuyProductName"].ToString() : null,
                GetProductID = row.Table.Columns.Contains("GetProductID") && row["GetProductID"] != DBNull.Value
                    ? Convert.ToInt32(row["GetProductID"]) : null,
                GetProductName = row.Table.Columns.Contains("GetProductName") && row["GetProductName"] != DBNull.Value
                    ? row["GetProductName"].ToString() : null,
                DiscountPercent = row.Table.Columns.Contains("DiscountPercent") && row["DiscountPercent"] != DBNull.Value
                    ? Convert.ToDecimal(row["DiscountPercent"]) : null,
                BundlePrice = row.Table.Columns.Contains("BundlePrice") && row["BundlePrice"] != DBNull.Value
                    ? Convert.ToDecimal(row["BundlePrice"]) : null,
                ApplicableOn = row.Table.Columns.Contains("ApplicableOn") && row["ApplicableOn"] != DBNull.Value
                    ? row["ApplicableOn"].ToString() ?? string.Empty : string.Empty,
                CategoryID = row.Table.Columns.Contains("CategoryID") && row["CategoryID"] != DBNull.Value
                    ? Convert.ToInt32(row["CategoryID"]) : null,
                CategoryName = row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != DBNull.Value
                    ? row["CategoryName"].ToString() : null,
                StartDate = row.Table.Columns.Contains("StartDate") && row["StartDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["StartDate"]) : DateTime.Now,
                EndDate = row.Table.Columns.Contains("EndDate") && row["EndDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["EndDate"]) : DateTime.Now,
                IsActive = row.Table.Columns.Contains("IsActive") && row["IsActive"] != DBNull.Value
                    ? Convert.ToBoolean(row["IsActive"]) : true,
                Priority = row.Table.Columns.Contains("Priority") && row["Priority"] != DBNull.Value
                    ? Convert.ToInt32(row["Priority"]) : 0,
                Description = row.Table.Columns.Contains("Description") && row["Description"] != DBNull.Value
                    ? row["Description"].ToString() : null,
                CreatedDate = row.Table.Columns.Contains("CreatedDate") && row["CreatedDate"] != DBNull.Value
                    ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.Now,
                CreatedBy = row.Table.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? Convert.ToInt32(row["CreatedBy"]) : null,
                CreatedByName = row.Table.Columns.Contains("CreatedByName") && row["CreatedByName"] != DBNull.Value
                    ? row["CreatedByName"].ToString() : null
            };
        }
    }
}