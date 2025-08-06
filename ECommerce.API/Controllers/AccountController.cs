using ECommerce.API.DTO;
using ECommerce.API.Entity;
using ECommerce.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public TokenService _tokenService { get; }

        public AccountController(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto req)
        {
            if (req == null)
            {
                return BadRequest("Invalid user data.");
            }

            var user = await _userManager.FindByNameAsync(req.UserName);
            if (user == null)
            {
                return BadRequest("UserName Hatalı");

            }
            

            var result = await _userManager.CheckPasswordAsync(user, req.Password);
            if (result)
            {
                return Ok( new {Token= await _tokenService.GenerateJWT(user)});
            }


            return Unauthorized();
            
        }

      

        [HttpPost("register")]

        public async Task<IActionResult> CreateUser(RegisterDto req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var user = new AppUser
            {
                UserName = req.UserName,
                Name = req.Name,
                Email = req.Email
            };

            var result = await _userManager.CreateAsync(user, req.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                return Created();
            }

            return BadRequest(result.Errors);

        }

       
    }
}
