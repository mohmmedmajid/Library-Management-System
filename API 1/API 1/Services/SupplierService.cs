using API_1.DTOs.Supplier;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<int> CreateAsync(CreateSupplierDTO dto)
        {
            ValidateSupplierDTO(dto);

            if (!string.IsNullOrWhiteSpace(dto.Phone))
            {
                var existing = await _supplierRepository.SearchAsync(dto.Phone);
                if (existing.Any(s => s.Phone == dto.Phone.Trim()))
                    throw new InvalidOperationException("A supplier with this phone number already exists");
            }

            var supplier = new Supplier
            {
                SupplierName = dto.SupplierName.Trim(),
                ContactPerson = dto.ContactPerson?.Trim(),
                Phone = dto.Phone?.Trim(),
                Email = dto.Email?.Trim(),
                Address = dto.Address?.Trim(),
                TaxNumber = dto.TaxNumber?.Trim(),
                CreditLimit = dto.CreditLimit,
                PaymentTerms = dto.PaymentTerms?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _supplierRepository.InsertAsync(supplier);
        }

        public async Task<bool> UpdateAsync(UpdateSupplierDTO dto)
        {
            if (dto.SupplierID <= 0)
                throw new ArgumentException("Invalid supplier ID");

            ValidateSupplierDTO(new CreateSupplierDTO
            {
                SupplierName = dto.SupplierName,
                Phone = dto.Phone,
                Email = dto.Email,
                CreditLimit = dto.CreditLimit
            });

            var existing = await _supplierRepository.GetByIdAsync(dto.SupplierID);
            if (existing == null)
                throw new InvalidOperationException("Supplier not found");

            var supplier = new Supplier
            {
                SupplierID = dto.SupplierID,
                SupplierName = dto.SupplierName.Trim(),
                ContactPerson = dto.ContactPerson?.Trim(),
                Phone = dto.Phone?.Trim(),
                Email = dto.Email?.Trim(),
                Address = dto.Address?.Trim(),
                TaxNumber = dto.TaxNumber?.Trim(),
                CreditLimit = dto.CreditLimit,
                PaymentTerms = dto.PaymentTerms?.Trim(),
                IsActive = dto.IsActive
            };

            return await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task<bool> UpdateTotalsAsync(UpdateSupplierTotalsDTO dto)
        {
            if (dto.SupplierID <= 0)
                throw new ArgumentException("Invalid supplier ID");

            var existing = await _supplierRepository.GetByIdAsync(dto.SupplierID);
            if (existing == null)
                throw new InvalidOperationException("Supplier not found");

            return await _supplierRepository.UpdateTotalsAsync(
                dto.SupplierID,
                dto.PurchaseAmount,
                dto.DebtAmount
            );
        }

        public async Task<bool> DeleteAsync(int supplierId)
        {
            if (supplierId <= 0)
                throw new ArgumentException("Invalid supplier ID");

            var existing = await _supplierRepository.GetByIdAsync(supplierId);
            if (existing == null)
                throw new InvalidOperationException("Supplier not found");

            if (existing.TotalDebt > 0)
                throw new InvalidOperationException("Cannot delete supplier with pending debt");

            return await _supplierRepository.DeleteAsync(supplierId);
        }

        public async Task<Supplier?> GetByIdAsync(int supplierId)
        {
            if (supplierId <= 0)
                throw new ArgumentException("Invalid supplier ID");

            return await _supplierRepository.GetByIdAsync(supplierId);
        }

        public async Task<List<Supplier>> GetAllAsync(bool? isActive = null)
        {
            return await _supplierRepository.GetAllAsync(isActive);
        }

        public async Task<List<Supplier>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("Search term is required");

            if (searchTerm.Trim().Length < 2)
                throw new ArgumentException("Search term must be at least 2 characters");

            return await _supplierRepository.SearchAsync(searchTerm.Trim());
        }

        public async Task<List<Supplier>> GetSuppliersWithDebtAsync()
        {
            return await _supplierRepository.GetSuppliersWithDebtAsync();
        }

        public async Task<(decimal TotalPurchases, decimal TotalDebt, int SupplierCount)> GetSupplierStatisticsAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync(true);

            var totalPurchases = suppliers.Sum(s => s.TotalPurchases);
            var totalDebt = suppliers.Sum(s => s.TotalDebt);
            var supplierCount = suppliers.Count;

            return (totalPurchases, totalDebt, supplierCount);
        }

        private void ValidateSupplierDTO(CreateSupplierDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SupplierName))
                throw new ArgumentException("Supplier name is required");

            if (dto.SupplierName.Trim().Length < 2)
                throw new ArgumentException("Supplier name must be at least 2 characters");

            if (!string.IsNullOrWhiteSpace(dto.Email) && !IsValidEmail(dto.Email.Trim()))
                throw new ArgumentException("Invalid email format");

            if (dto.CreditLimit < 0)
                throw new ArgumentException("Credit limit cannot be negative");
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
    }
}