using Microsoft.EntityFrameworkCore;
using ProductCatalogData.Database;
using ProductCatalogData.Entities;
using ProductCatalogMini.Services.DTOs.Suppliers;
using ProductCatalogMini.Services.Interfaces;

namespace ProductCatalogMini.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierListDto>> GetAllAsync()
        {
            return await _context.Suppliers
                .Select(s => new SupplierListDto
                {
                    Id = s.Id,
                    CompanyName = s.CompanyName
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateSupplierDto dto)
        {
            var supplier = new Supplier
            {
                CompanyName = dto.CompanyName,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }
    }
}