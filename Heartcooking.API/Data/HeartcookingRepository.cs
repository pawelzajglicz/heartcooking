using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Heartcooking.API.Models;

namespace Heartcooking.API.Data
{
    public class HeartcookingRepository : IHeartcookingRepository
    {
        private readonly IMemoryCache cache;
        private readonly DataContext context;
        private readonly ILogger<HeartcookingRepository> logger;

        private readonly string productsCacheKey = "products";

        public HeartcookingRepository(DataContext context, ILogger<HeartcookingRepository> logger, IMemoryCache cache)
        {
            this.cache = cache;
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
            IEnumerable<Product> products = cache.Get<IEnumerable<Product>>(productsCacheKey);
            if (products == null)
            {
                logger.LogTrace($"Fetch products from context");
                products = await context.Products.ToListAsync();
                cache.Set(productsCacheKey, products, TimeSpan.FromMinutes(1));
            }
            else
            {
                logger.LogTrace($"Fetch products from cache");
            }

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