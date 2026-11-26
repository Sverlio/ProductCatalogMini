using ProductCatalogMini.Services.DTOs.Categories;

namespace ProductCatalogMini.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryListDto>> GetAllAsync();
        Task CreateAsync(CreateCategoryDto dto);
    }
}