using ECommerce.Application.Interfaces.Tokens;
using ECommerce.Infrastructure.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ECommerce.Mapper
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Microsoft.Extensions.Options.ConfigurationExtensions Nuget paketi indirerek appsettings deki yapıyı classıma çevirdim.
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
            services.AddTransient<ITokenService, TokenService>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer= configuration["JWT:Issuer"],
                    ValidAudience= configuration["JWT:Audience"],
                    ClockSkew=TimeSpan.Zero
                };
            });

        
        }
    }
}


//ValidateIssuer = false,
//                    ValidateAudience = false,
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
//                    ValidateLifetime = false