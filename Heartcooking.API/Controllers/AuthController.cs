using System.Threading.Tasks;
using Heartcooking.API.Data;
using Heartcooking.API.Dtos;
using Heartcooking.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Heartcooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repository;
        public AuthController(IAuthRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await repository.UsernameTaken(userForRegisterDto.Username))
                return BadRequest("This username has been taken.");

            User userToCreate = new User 
            {
                Username = userForRegisterDto.Username
            };

            User createdUser = await repository.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}