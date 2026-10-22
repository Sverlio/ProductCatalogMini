using Microsoft.EntityFrameworkCore;
using ProductCatalogData.Entities;

namespace ProductCatalogData.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Химикалка Blue Gel", Brand = "Faber-Castell", Category = "Пишещи средства", Price = 2.50m, Quantity = 150 },
                new Product { Id = 2, Name = "Тетрадка А5 (80 листа)", Brand = "Miquelrius", Category = "Хартиени изделия", Price = 4.80m, Quantity = 80 },
                new Product { Id = 3, Name = "Маркер жълт", Brand = "Stabilo", Category = "Пишещи средства", Price = 3.20m, Quantity = 45 }
            );
        }
    }
}