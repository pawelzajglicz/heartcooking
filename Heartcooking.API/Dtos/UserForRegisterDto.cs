using System.ComponentModel.DataAnnotations;

namespace Heartcooking.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "You must specify password betweene 6 and 32 characters")]
        public string Password { get; set; }
    }
}