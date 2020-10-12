using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using Heartcooking.API.Data;
using Heartcooking.API.Dtos;
using Heartcooking.API.Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IHeartcookingRepository repository;
        private readonly IMapper mapper;

        public ProductsController(IHeartcookingRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            IEnumerable<Product> products = await repository.GetProducts();

            IEnumerable<ProductForListDto> productsToReturn = mapper.Map<IEnumerable<ProductForListDto>>(products);

            return Ok(productsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            Product product = await repository.GetProduct(id);

            ProductForDetailedDto productToReturn = mapper.Map<ProductForDetailedDto>(product);

            return Ok(productToReturn);
        }
    }
}