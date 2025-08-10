using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTO
{
    public class UserDto
    {
        public string Name { get; set; } = null!;

        public string Token {get; set;} = null!;
    }
}