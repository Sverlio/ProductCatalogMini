using System.ComponentModel.DataAnnotations;
using ProductCatalogData.Enums;

namespace ProductCatalogMini.ViewModels.Products
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името на продукта е задължително.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 100 символа.")]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Цената е задължителна.")]
        [Range(0.01, 100000, ErrorMessage = "Цената трябва да бъде положително число.")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Наличността е задължителна.")]
        [Range(0, 100000, ErrorMessage = "Наличността не може да бъде отрицателна.")]
        [Display(Name = "Наличност")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Статусът е задължителен.")]
        [Display(Name = "Статус")]
        public ProductStatus Status { get; set; }

        [Required(ErrorMessage = "Изберете категория.")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        [Display(Name = "Доставчик")]
        public int? SupplierId { get; set; }
    }
}