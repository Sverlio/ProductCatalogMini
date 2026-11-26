using System.ComponentModel.DataAnnotations;

namespace ProductCatalogData.Entities
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string ReviewerName { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}