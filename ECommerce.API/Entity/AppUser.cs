using Microsoft.AspNetCore.Identity;

namespace ECommerce.API.Entity
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }

    }
}
