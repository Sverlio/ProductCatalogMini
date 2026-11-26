using ProductCatalogData.Enums;

namespace ProductCatalogMini.Services.DTOs.Products
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public ProductStatus Status { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? SupplierName { get; set; }
    }
}