using ProductCatalogData.Enums;

namespace ProductCatalogMini.Services.DTOs.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public ProductStatus Status { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}