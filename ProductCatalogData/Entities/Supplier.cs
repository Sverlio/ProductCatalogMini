using System.ComponentModel.DataAnnotations;

namespace ProductCatalogData.Entities
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(120)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [MaxLength(30)]
        public string Phone { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}