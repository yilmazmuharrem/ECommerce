using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException :BaseExceptions
    {
        public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var !"){ }
    }
}
