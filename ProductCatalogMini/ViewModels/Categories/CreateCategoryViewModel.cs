using System.ComponentModel.DataAnnotations;

namespace ProductCatalogMini.ViewModels.Categories
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Името на категорията е задължително.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 80 символа.")]
        [Display(Name = "Име")]
        public string Name { get; set; } = string.Empty;

        [StringLength(300, ErrorMessage = "Описанието може да бъде до 300 символа.")]
        [Display(Name = "Описание")]
        public string? Description { get; set; }
    }
}