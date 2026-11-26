using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalogData.Enums;

namespace ProductCatalogMini.ViewModels.Products
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Името на продукта е задължително.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 100 символа.")]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Марката е задължителна.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Марката трябва да е между 2 и 80 символа.")]
        [Display(Name = "Марка")]
        public string Brand { get; set; } = string.Empty;

        [Range(0.01, 1000000, ErrorMessage = "Цената трябва да бъде положително число.")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Наличното количество не може да бъде отрицателно.")]
        [Display(Name = "Налично количество")]
        public int StockQuantity { get; set; }

        [Display(Name = "Статус")]
        public ProductStatus Status { get; set; } = ProductStatus.InStock;

        [Required(ErrorMessage = "Изберете категория.")]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        [Display(Name = "Доставчик")]
        public int? SupplierId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Suppliers { get; set; } = new List<SelectListItem>();
    }
}