using Microsoft.EntityFrameworkCore;

namespace Buoi17_First.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Định nghĩa cho từng Entity
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(c => new { c.CategoryId });
                e.Property(c => c.CategoryName).IsRequired().HasMaxLength(150);
                e.HasIndex(c => c.CategoryName).IsUnique(true);
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(p => new { p.ProductId });
                e.Property(p => p.ProductName).IsRequired();
                e.Property(p => p.Price).HasDefaultValue(0);

                e.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .HasConstraintName("FK_Product_Category")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ProductPrice>(e =>
            {
                e.ToTable("ProductPrice");
                e.HasKey(pp => new { pp.ProductId, pp.SizeId, pp.ColorId });
            });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
