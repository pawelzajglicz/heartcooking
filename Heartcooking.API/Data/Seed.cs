using Heartcooking.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Heartcooking.API.Data
{
    public class Seed
    {
        public static void SeedProducts(DataContext context)
        {
            if (!context.Products.Any())
            {
                var productData = System.IO.File.ReadAllText("Data/ProductSeedData.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productData);

                products.ForEach(product => 
                {
                    context.Products.Add(product);
                });

                context.SaveChanges();
            }
        }
    }
}