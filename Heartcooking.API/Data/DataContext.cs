using Heartcooking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ProductAllergen> ProductsAllergens { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductAllergen>()
                .HasKey(pa => new { pa.AllergenId, pa.ProductId });

            modelBuilder.Entity<ProductAllergen>()
                .HasOne(pa => pa.Allergen)
                .WithMany(a => a.ProductsAllergens)
                .HasForeignKey(pa => pa.AllergenId);

            modelBuilder.Entity<ProductAllergen>()
                .HasOne(pa => pa.Product)
                .WithMany(p => p.ProductsAllergens)
                .HasForeignKey(pa => pa.ProductId);
        }
    }
}