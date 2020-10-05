using Heartcooking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Allergen> Allergens {get; set;}
        public DbSet<Photo> Photos {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<User> Users {get; set;}
    }
}