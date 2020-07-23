using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Product> Ingredients {get; set;}
    }
}