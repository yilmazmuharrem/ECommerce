using ECommerce.API.Data;
using ECommerce.API.DTO;
using ECommerce.API.Entity;
using ECommerce.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public  TokenService _tokenService { get; }

        private  AppDbContext _context { get; }

        public AccountController(UserManager<AppUser> userManager, TokenService tokenService,AppDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto req)
        {
            if (req == null)
            {
                return BadRequest("Invalid user data.");
            }

            var user = await _userManager.FindByNameAsync(req.UserName);
            if (user == null)
            {
                return BadRequest( new ProblemDetails { Title = "UserName Hatalı" });

            }
            

            var result = await _userManager.CheckPasswordAsync(user, req.Password);
            if (result)
            {
                var userCart = await GetOrCreate(req.UserName);
                var cookieCart = await GetOrCreate(Request.Cookies["customerId"]!);

                if (userCart != null)
                {
                    foreach (var item in userCart.CardItems)
                    {
                        cookieCart.AddItem(item.Product,item.Quantity);
                    }

                    _context.Cards.Remove(userCart);
                }

                cookieCart.CustomerId = req.UserName;
                await _context.SaveChangesAsync();

                return Ok( new UserDto {
                    Name=user.Name!,
                    Token = await _tokenService.GenerateJWT(user)});
            }


            return Unauthorized();
            
        }
        private async Task<Card> GetOrCreate(string custId)
        {
            var cart = await _context.Cards
                    .Include(i => i.CardItems)
                    .ThenInclude(i => i.Product)
                    .Where(i => i.CustomerId == custId)
                    .FirstOrDefaultAsync();

            if (cart == null)
            {
                var customerId = User.Identity?.Name;

                if (string.IsNullOrEmpty(customerId))
                {
                    customerId = Guid.NewGuid().ToString();
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddMonths(1),
                        IsEssential = true
                    };
                    Response.Cookies.Append("customerId", customerId, cookieOptions);
                }
                cart = new Card { CustomerId = customerId };

                _context.Cards.Add(cart);
                await _context.SaveChangesAsync();
            }

            return cart;
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


        [Authorize]
        [HttpGet("getuser")]
        public async Task<ActionResult<UserDto>> GetUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name!);
            if (user == null)
            {
                return BadRequest(new ProblemDetails { Title = "Username ya da parola Hatalı" });
            }

            return new UserDto
            {
                Name = user.Name!,
                Token = await _tokenService.GenerateJWT(user)
            };
        }

    }
}
