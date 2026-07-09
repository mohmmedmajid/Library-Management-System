using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IPromotionalOfferRepository
    {
        Task<int> InsertAsync(PromotionalOffer offer);
        Task<bool> UpdateAsync(PromotionalOffer offer);
        Task<bool> DeleteAsync(int offerId);
        Task<PromotionalOffer?> GetByIdAsync(int offerId);
        Task<List<PromotionalOffer>> GetAllAsync(bool? isActive = null, bool currentOnly = false);
        Task<List<PromotionalOffer>> GetActiveOffersForProductAsync(int productId, int categoryId);
    }
}