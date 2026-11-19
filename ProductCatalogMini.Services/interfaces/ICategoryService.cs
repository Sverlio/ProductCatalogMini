using ProductCatalogData.Entities;

namespace ProductCatalogMini.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task CreateAsync(Category category);
    }
}