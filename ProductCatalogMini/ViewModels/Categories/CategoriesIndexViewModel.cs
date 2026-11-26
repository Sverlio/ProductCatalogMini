using ProductCatalogMini.Services.DTOs.Categories;

namespace ProductCatalogMini.ViewModels.Categories
{
    public class CategoriesIndexViewModel
    {
        public List<CategoryListDto> Categories { get; set; } = new();
    }
}