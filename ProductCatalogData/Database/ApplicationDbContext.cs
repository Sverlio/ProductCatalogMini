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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", t =>
                {
                    t.HasCheckConstraint("CK_Product_Price_Positive", "[Price] > 0");
                    t.HasCheckConstraint("CK_Product_StockQuantity_NonNegative", "[StockQuantity] >= 0");
                });

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Brand)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(p => p.Price)
                    .HasPrecision(18, 2);

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Supplier)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.SupplierId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(c => c.Description)
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(s => s.CompanyName)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(s => s.Email)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(s => s.Phone)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Reviews", t =>
                {
                    t.HasCheckConstraint("CK_Review_Rating_Range", "[Rating] >= 1 AND [Rating] <= 5");
                });

                entity.Property(r => r.ReviewerName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(r => r.Comment)
                    .HasMaxLength(500);

                entity.HasOne(r => r.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(r => r.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}