using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Heartcooking.API.Data;
using Heartcooking.API.Dtos;
using Heartcooking.API.Exceptions;
using Heartcooking.API.Models;
using Heartcooking.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Heartcooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IConfiguration configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            this.authService = authService;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            User userToRegister = new User 
            {
                Username = userForRegisterDto.Username
            };

            try 
            {
                await authService.Register(userToRegister, userForRegisterDto.Password);
            } 
            catch (UsernameTakenException exc) 
            {
                return BadRequest(exc.Message);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            User userToLogin = new User 
            {
                Username = userForLogin.Username
            };

            string token;
            try 
            {
                token = await authService.Login(userToLogin, userForLogin.Password);
            } 
            catch (AuthenticationException exc) 
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}