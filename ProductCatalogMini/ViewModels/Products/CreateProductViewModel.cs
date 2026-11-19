using System.ComponentModel.DataAnnotations;
using ProductCatalogData.Enums;

namespace ProductCatalogMini.ViewModels.Products
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Imeto na produkta e zadaljitelno.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Imeto tryabva da e mezhdu 2 i 100 simvola.")]
        [Display(Name = "Ime")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cenata e zadaljitelna.")]
        [Range(0.01, 100000, ErrorMessage = "Cenata tryabva da bade polozhitelno chislo.")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Nalichnostta e zadaljitelna.")]
        [Range(0, 100000, ErrorMessage = "Nalichnostta ne moze da bade otricatelna.")]
        [Display(Name = "Nalichnost")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Statusat e zadaljitelel.")]
        [Display(Name = "Status")]
        public ProductStatus Status { get; set; } = ProductStatus.InStock;

        [Required(ErrorMessage = "Izberete kategoriya.")]
        [Display(Name = "Kategoriya")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Izberete dostavchik.")]
        [Display(Name = "Dostavchik")]
        public int SupplierId { get; set; }
    }
}