using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"ingredient1", "ingredient2"};
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"ingredient with id {id}";
        }
    }
}