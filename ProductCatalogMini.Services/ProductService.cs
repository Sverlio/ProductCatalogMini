using Microsoft.EntityFrameworkCore;
using ProductCatalogData.Database;
using ProductCatalogData.Entities;
using ProductCatalogMini.Services.DTOs.Products;
using ProductCatalogMini.Services.Interfaces;

namespace ProductCatalogMini.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductListDto>> GetAllAsync()
        {
            return await _context.Products
                .Select(p => new ProductListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    Status = p.Status,
                    CategoryName = p.Category != null ? p.Category.Name : string.Empty,
                    SupplierName = p.Supplier != null ? p.Supplier.CompanyName : string.Empty
                })
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product?> GetDetailsByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                Status = dto.Status,
                CategoryId = dto.CategoryId,
                SupplierId = dto.SupplierId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EditProductDto dto)
        {
            var product = await _context.Products.FindAsync(dto.Id);
            if (product == null)
            {
                return;
            }

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;
            product.Status = dto.Status;
            product.CategoryId = dto.CategoryId;
            product.SupplierId = dto.SupplierId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public async Task<(List<Category> Categories, List<Supplier> Suppliers)> GetDropdownDataAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var suppliers = await _context.Suppliers.ToListAsync();
            return (categories, suppliers);
        }
    }
}