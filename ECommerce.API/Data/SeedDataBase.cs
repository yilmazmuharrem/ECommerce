using ECommerce.API.Entity;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.API.Data
{
    public static class SeedDataBase
    {
        public static async void Initialize(IApplicationBuilder app)
        {
            var useManager = app.ApplicationServices.CreateScope()
                  .ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var roleManager = app.ApplicationServices.CreateScope()
                  .ServiceProvider.GetRequiredService<RoleManager<AppRole>>();


            if (!roleManager.Roles.Any())
            {
                var customer = new AppRole
                {
                    Name = "Customer",
                };

                var admin = new AppRole
                {
                    Name = "Admin",
                };

                await roleManager.CreateAsync(customer);
                await roleManager.CreateAsync(admin);
            }

            if (!useManager.Users.Any())
            {
                var customer = new AppUser
                {
                    Name = "Elif Beyza",
                    UserName = "elifbeyza",
                    Email = "saglame99@gmail.com"
                };
                var admin = new AppUser
                {
                    Name = "muharrem",
                    UserName = "muharremyilmaz",
                    Email = "muharremyilmaz656@gmail.com"
                };

                await useManager.CreateAsync(customer,"Antep27.");
                await useManager.AddToRoleAsync(customer, "Customer");
                await useManager.CreateAsync(admin,"1Ecrin.ayaz");
                await useManager.AddToRolesAsync(admin, ["Admin","Customer"]);

            }
        }
    }
}
