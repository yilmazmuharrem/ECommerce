using static ECommerce.API.Entity.Card;

namespace ECommerce.API.DTO
{
    public class CardDto
    {
        public int CardId { get; set; }
        public string CustomerId { get; set; } = null!;
        public List<CardItemDto> CartItems { get; set; } = new();
    }
    public class CardItemDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    };
}
