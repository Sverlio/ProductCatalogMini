using ProductCatalogData.Entities;

namespace ProductCatalogMini.Services.interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetDetailsByIdAsync(int id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        bool Exists(int id);
        Task<(List<Category> Categories, List<Supplier> Suppliers)> GetDropdownDataAsync();
    }
}