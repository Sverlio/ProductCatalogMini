using System.ComponentModel.DataAnnotations;

namespace ProductCatalogMini.ViewModels.Suppliers
{
    public class CreateSupplierViewModel
    {
        [Required(ErrorMessage = "Името на фирмата е задължително.")]
        [StringLength(120, MinimumLength = 2, ErrorMessage = "Името на фирмата трябва да е между 2 и 120 символа.")]
        [Display(Name = "Фирма")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Имейлът е задължителен.")]
        [EmailAddress(ErrorMessage = "Въведете валиден имейл адрес.")]
        [StringLength(120, ErrorMessage = "Имейлът може да бъде до 120 символа.")]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Телефонът е задължителен.")]
        [Phone(ErrorMessage = "Въведете валиден телефонен номер.")]
        [StringLength(30, ErrorMessage = "Телефонът може да бъде до 30 символа.")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; } = string.Empty;
    }
}