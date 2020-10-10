using System.Collections.Generic;
using System.Threading.Tasks;
using Heartcooking.API.Models;

namespace Heartcooking.API.Data
{
    public interface IHeartcookingRepository
    {

         Task<Product> GetProduct(int id);

         Task<IEnumerable<Product>> GetProducts();
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
    }
}