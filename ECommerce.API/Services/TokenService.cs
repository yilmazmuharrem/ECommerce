using ECommerce.API.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public UserManager<AppUser> _userManager { get; }
        public TokenService(UserManager<AppUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;

        }


        public async Task<string> GenerateJWT(AppUser user)
        {
            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.Email, user.Email ??""),
              new Claim(ClaimTypes.NameIdentifier, user.Id),
              new Claim(ClaimTypes.Name, user.UserName!),

            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JwtSecurity:SecretKey"]!));

            var tokenSettings = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Issuer= "ECommerce.API",
                Audience = "ECommerce.API",
            };

            var token = tokenHandler.CreateToken(tokenSettings);
            return tokenHandler.WriteToken(token);
        }
    }
}
