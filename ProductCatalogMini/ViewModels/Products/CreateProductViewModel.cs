using System.ComponentModel.DataAnnotations;
using ProductCatalogData.Enums;

namespace ProductCatalogMini.ViewModels.Products
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Името трябва да бъде между 2 и 100 символа.")]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Цената е задължителна.")]
        [Range(0.01, 100000, ErrorMessage = "Цената трябва да бъде положително число.")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Наличността е задължителна.")]
        [Range(0, 100000, ErrorMessage = "Наличността не може да бъде отрицателно число.")]
        [Display(Name = "Наличност")]
        public int StockQuantity { get; set; }

        [EnumDataType(typeof(ProductStatus))]
        [Display(Name = "Статус")]
        public ProductStatus Status { get; set; } = ProductStatus.InStock;

        [Range(1, int.MaxValue, ErrorMessage = "Изберете категория.")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        [Display(Name = "Доставчик")]
        public int? SupplierId { get; set; }
    }
}