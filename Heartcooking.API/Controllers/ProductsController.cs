using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"product1", "product2"};
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"product with id {id}";
        }
    }
}