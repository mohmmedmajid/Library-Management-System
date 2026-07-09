using API_1.DTOs.SalesRepresentative;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class SalesRepresentativeService : ISalesRepresentativeService
    {
        private readonly ISalesRepresentativeRepository _salesRepRepository;

        public SalesRepresentativeService(ISalesRepresentativeRepository salesRepRepository)
        {
            _salesRepRepository = salesRepRepository;
        }

        public async Task<int> CreateAsync(CreateSalesRepresentativeDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.RepName))
                throw new ArgumentException("Representative name is required");

            if (dto.CommissionPercent < 0 || dto.CommissionPercent > 100)
                throw new ArgumentException("Commission percent must be between 0 and 100");

            if (!string.IsNullOrWhiteSpace(dto.Email) && !IsValidEmail(dto.Email))
                throw new ArgumentException("Invalid email format");

            if (!string.IsNullOrWhiteSpace(dto.Phone) && !IsValidPhone(dto.Phone))
                throw new ArgumentException("Invalid phone format");

            var salesRep = new SalesRepresentative
            {
                RepName = dto.RepName.Trim(),
                Phone = dto.Phone?.Trim(),
                Email = dto.Email?.Trim(),
                CommissionPercent = dto.CommissionPercent,
                CreatedBy = dto.CreatedBy
            };

            return await _salesRepRepository.InsertAsync(salesRep);
        }

        public async Task<bool> UpdateAsync(UpdateSalesRepresentativeDTO dto)
        {
            if (dto.SalesRepID <= 0)
                throw new ArgumentException("Invalid sales representative ID");

            if (string.IsNullOrWhiteSpace(dto.RepName))
                throw new ArgumentException("Representative name is required");

            if (dto.CommissionPercent < 0 || dto.CommissionPercent > 100)
                throw new ArgumentException("Commission percent must be between 0 and 100");

            if (!string.IsNullOrWhiteSpace(dto.Email) && !IsValidEmail(dto.Email))
                throw new ArgumentException("Invalid email format");

            if (!string.IsNullOrWhiteSpace(dto.Phone) && !IsValidPhone(dto.Phone))
                throw new ArgumentException("Invalid phone format");

            var existing = await _salesRepRepository.GetByIdAsync(dto.SalesRepID);
            if (existing == null)
                throw new InvalidOperationException("Sales representative not found");

            var salesRep = new SalesRepresentative
            {
                SalesRepID = dto.SalesRepID,
                RepName = dto.RepName.Trim(),
                Phone = dto.Phone?.Trim(),
                Email = dto.Email?.Trim(),
                CommissionPercent = dto.CommissionPercent,
                IsActive = dto.IsActive
            };

            return await _salesRepRepository.UpdateAsync(salesRep);
        }

        public async Task<bool> DeleteAsync(int salesRepId)
        {
            if (salesRepId <= 0)
                throw new ArgumentException("Invalid sales representative ID");

            var existing = await _salesRepRepository.GetByIdAsync(salesRepId);
            if (existing == null)
                throw new InvalidOperationException("Sales representative not found");

            return await _salesRepRepository.DeleteAsync(salesRepId);
        }

        public async Task<SalesRepresentative?> GetByIdAsync(int salesRepId)
        {
            if (salesRepId <= 0)
                throw new ArgumentException("Invalid sales representative ID");

            return await _salesRepRepository.GetByIdAsync(salesRepId);
        }

        public async Task<List<SalesRepresentative>> GetAllAsync(bool? isActive = null)
        {
            return await _salesRepRepository.GetAllAsync(isActive);
        }

        public async Task<bool> UpdateTotalsAsync(int salesRepId, decimal salesAmount, decimal commissionAmount)
        {
            if (salesRepId <= 0)
                throw new ArgumentException("Invalid sales representative ID");

            if (salesAmount < 0)
                throw new ArgumentException("Sales amount cannot be negative");

            if (commissionAmount < 0)
                throw new ArgumentException("Commission amount cannot be negative");

            var existing = await _salesRepRepository.GetByIdAsync(salesRepId);
            if (existing == null)
                throw new InvalidOperationException("Sales representative not found");

            return await _salesRepRepository.UpdateTotalsAsync(salesRepId, salesAmount, commissionAmount);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {

            string cleanPhone = new string(phone.Where(c => char.IsDigit(c)).ToArray());


            return cleanPhone.Length >= 7 && cleanPhone.Length <= 15;
        }
    }
}
