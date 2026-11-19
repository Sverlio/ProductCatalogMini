using ProductCatalogMini.Services.DTOs.Products;

namespace ProductCatalogMini.ViewModels.Products
{
    public class ProductsIndexViewModel
    {
        public List<ProductListDto> Products { get; set; } = new();
    }
}