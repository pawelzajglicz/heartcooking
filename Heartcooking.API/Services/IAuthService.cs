using System.Security.Claims;
using System.Threading.Tasks;
using Heartcooking.API.Dtos;
using Heartcooking.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Heartcooking.API.Services
{
    public interface IAuthService
    {
        Task<User> Register(User userToRegister, string password);
        Task<string> Login(User userToLogin, string password);
    }
}