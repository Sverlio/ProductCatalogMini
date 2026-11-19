using ProductCatalogData.Entities;
using ProductCatalogMini.Services.DTOs.Products;

namespace ProductCatalogMini.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductListDto>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetDetailsByIdAsync(int id);
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        bool Exists(int id);
        Task<(List<Category> Categories, List<Supplier> Suppliers)> GetDropdownDataAsync();
    }
}