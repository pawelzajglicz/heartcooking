using System.Threading.Tasks;
using Heartcooking.API.Models;

namespace Heartcooking.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UsernameTaken(string username);
    }
}
