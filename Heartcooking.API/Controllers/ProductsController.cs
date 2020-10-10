using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Heartcooking.API.Data;
using Heartcooking.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IHeartcookingRepository repository;

        public ProductsController(IHeartcookingRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            IEnumerable<Product> products = await repository.GetProducts();
            
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            Product product = await repository.GetProduct(id);

            return Ok(product);
        }
    }
}