using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password {get; set;} = null!;
    }
}