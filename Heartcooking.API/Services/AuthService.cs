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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Heartcooking.API.Services
{
    public class AuthService : IAuthService
    {        
        
        private readonly IAuthRepository repository;
        private readonly IConfiguration configuration;

        public AuthService(IAuthRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }
        public async Task<User> Register(User userToRegister, string password)
        {

            userToRegister.Username = userToRegister.Username.ToLower();

            if (await repository.UsernameTaken(userToRegister.Username))
                throw new UsernameTakenException();
            
            User createdUser = await repository.Register(userToRegister, password);

            return createdUser;
        }

        public async Task<String> Login(User userForLogin, string password)
        {
            
            User userFromRepo = await repository.Login(userForLogin.Username.ToLower(), password);

            if (userFromRepo == null)
                throw new AuthenticationException();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string writtenToken = tokenHandler.WriteToken(token);

            return writtenToken;
        }
    }
}