using API_1.DTOs.PromotionalOffer;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IPromotionalOfferService
    {
        Task<int> CreateAsync(CreatePromotionalOfferDTO dto);
        Task<bool> UpdateAsync(UpdatePromotionalOfferDTO dto);
        Task<bool> DeleteAsync(int offerId);
        Task<PromotionalOffer?> GetByIdAsync(int offerId);
        Task<List<PromotionalOffer>> GetAllAsync(GetAllOffersDTO dto);
        Task<List<PromotionalOffer>> GetActiveOffersAsync();
        Task<List<PromotionalOffer>> GetActiveOffersForProductAsync(GetActiveOffersForProductDTO dto);
    }
}