using System.ComponentModel.DataAnnotations;
using ProductCatalogData.Enums;

namespace ProductCatalogData.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(80)]
        public string Brand { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public ProductStatus Status { get; set; } = ProductStatus.InStock;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}