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
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Heartcooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthController> logger;

        public AuthController(IAuthService authService, IConfiguration configuration, ILogger<AuthController> logger)
        {
            this.authService = authService;
            this.configuration = configuration;
            this.logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            logger.LogInformation("Starting register user");
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
                logger.LogDebug($"Username {userForRegisterDto.Username} was taken");
                return BadRequest(exc.Message);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            logger.LogInformation($"Starting logging user with name {userForLogin.Username}");
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
                logger.LogDebug($"At logging user with name {userForLogin.Username} occured AuthenticationException with message {exc.Message}");
                return Unauthorized();
            }

            logger.LogInformation($"User with name {userForLogin.Username} logged succesfully");
            return Ok(new 
                {
                    token = token
                });
        }
    }
}