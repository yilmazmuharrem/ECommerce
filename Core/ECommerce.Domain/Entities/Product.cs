using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {

        }
        public Product(string title, string descriptipon, int brandId, decimal price, decimal discount)
        {
            Title = title;
            Descriptipon = descriptipon;
            BrandId = brandId;
            Price = price;
            Discount = discount;
        }
        public string Title { get; set; }
        public string Descriptipon { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
