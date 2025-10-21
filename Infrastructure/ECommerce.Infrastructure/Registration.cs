using ECommerce.Infrastructure.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Mapper
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Microsoft.Extensions.Options.ConfigurationExtensions Nuget paketi indirerek appsettings deki yapıyı classıma çevirdim.
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));

        }
    }
}
