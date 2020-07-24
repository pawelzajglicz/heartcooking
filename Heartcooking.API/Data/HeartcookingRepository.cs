using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class HeartcookingRepository : IHeartcookingRepository
    {
        private readonly DataContext context;
        
        public HeartcookingRepository(DataContext context)
        {
            this.context = context;
        }
        


        public async Task<Product> GetProduct(int id)
        {
            Product product = await context.Products.FirstOrDefaultAsync(product => product.Id == id);

            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> products = await context.Products.ToListAsync();;

            return products;
        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}