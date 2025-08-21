using static ECommerce.API.Entity.Card;

namespace ECommerce.API.Entity
{
    public class Card
    {
        public int CardId { get; set; }
        public string CustomerId { get; set; } = null!;
        public List<CardItem> CardItems { get; set; } = new();

        public void AddItem(Product product, int quantity)
        {
            var item = CardItems.Where(c => c.ProductId == product.Id).FirstOrDefault();

            if (item == null)
            {
                CardItems.Add(new CardItem { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveCardItem(int productId, int quantity)
        {
            
            var item = CardItems.FirstOrDefault(x => x.ProductId == productId);
            if (item == null)
            {
                return;
            }
            if (item.Quantity >= quantity)
            {
                item.Quantity -= quantity;
            }
             if (item.Quantity == 0)
            {
                CardItems.Remove(item);
            }
            
        }

        public double CalculateTotal()
        {
            return (double)CardItems.Sum(i => i.Product.Price * i.Quantity);
        }
        public class CardItem
        {
            public int CardItemId { get; set; }
            public int ProductId { get; set; }
            public Product Product { get; set; } = null!;
            public int CardId { get; set; }
            public int Quantity { get; set; }

        }
    }
}
