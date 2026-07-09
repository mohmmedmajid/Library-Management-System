using API_1.DTOs.Exchange;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IExchangeService
    {
        Task<int> CreateAsync(CreateExchangeDTO dto);
        Task<ExchangeTransaction?> GetByIdAsync(int exchangeId);
        Task<List<ExchangeTransaction>> GetAllAsync(DateTime? startDate, DateTime? endDate);
    }
}