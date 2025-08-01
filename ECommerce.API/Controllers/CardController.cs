using ECommerce.API.Data;
using ECommerce.API.DTO;
using ECommerce.API.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CardController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<CardDto>> GetCard()
        {
            var card = await GetOrCreate()!;
            return CardToDto(card);

        }

        [HttpPost]
        public async Task<ActionResult<Card>> AddItemToCard(int productId, int quantity)
        {
            var cart = await GetOrCreate();

            var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == productId);

            if (product == null)
                return NotFound("the product is not in database");

            cart.AddItem(product, quantity);

            var result = await _context.SaveChangesAsync() > 0;

            if (result)
                return CreatedAtAction(nameof(GetCard), CardToDto(cart));

            return BadRequest(new ProblemDetails { Title = "The product can not be added to cart" });

        }

        [HttpDelete]

        public async Task<ActionResult> DeleteItemFromCard(int productId, int quantity)
        {
            var cart = await GetOrCreate();
            cart.RemoveCardItem(productId, quantity);
            var result = await _context.SaveChangesAsync() > 0;
            if (result)
            {
                return CreatedAtAction(nameof(GetCard), CardToDto(cart));
            }
            return BadRequest(new ProblemDetails { Title = "The product can not be removed from cart" });
        }



        private async Task<Card> GetOrCreate()
        {
            var cart = await _context.Cards
                    .Include(i => i.CardItems)
                    .ThenInclude(i => i.Product)
                    .Where(i => i.CustomerId == Request.Cookies["customerId"])
                    .FirstOrDefaultAsync();

            if (cart == null)
            {
                var customerId = Guid.NewGuid().ToString();

                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMonths(1),
                    IsEssential = true
                };

                Response.Cookies.Append("customerId", customerId, cookieOptions);
                cart = new Card { CustomerId = customerId };

                _context.Cards.Add(cart);
                await _context.SaveChangesAsync();
            }

            return cart;
        }
        
        private  CardDto CardToDto(Card card)
        {
            return new CardDto
            {
                CardId = card.CardId,
                CustomerId = card.CustomerId,
                CartItems = card.CardItems.Select(i => new CardItemDto
                {
                    Quantity = i.Quantity,
                    ProductId = i.ProductId,
                    ImageUrl = i.Product.ImageUrl,
                    Name = i.Product.Name,
                    Price = i.Product.Price
                }).ToList()
            };
        }

    }
}
