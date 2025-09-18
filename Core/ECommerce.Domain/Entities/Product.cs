using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Product:EntityBase
    {
        public required string Title { get; set; }
        public required string Descriptipon { get; set; }
        public int BrandId { get; set; }
        public required decimal Price { get; set; }
        public required decimal Discount { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
