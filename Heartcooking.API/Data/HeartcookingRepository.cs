using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Data
{
    public class HeartcookingRepository : IHeartcookingRepository
    {
        private readonly DataContext context;
        private readonly ILogger<HeartcookingRepository> logger;

        public HeartcookingRepository(DataContext context, ILogger<HeartcookingRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        


        public async Task<Product> GetProduct(int id)
        {
            logger.LogTrace($"Fetch product with id {id}");
            Product product = await context.Products.FirstOrDefaultAsync(product => product.Id == id);

            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            logger.LogTrace($"Fetch products");
            IEnumerable<Product> products = await context.Products.ToListAsync();;

            return products;
        }
        public void Add<T>(T entity) where T : class
        {
            logger.LogTrace($"Adding entity {entity.ToString()}");
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            logger.LogTrace($"Deleting entity {entity.ToString()}");
            context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            logger.LogTrace($"Saving all changes");
            return await context.SaveChangesAsync() > 0;
        }
    }
}