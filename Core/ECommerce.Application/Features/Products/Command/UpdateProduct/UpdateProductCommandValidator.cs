using FluentValidation;

namespace ECommerce.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);

            RuleFor(x => x.Title).NotEmpty().WithName("Başlık");

            RuleFor(x => x.Descriptipon).NotEmpty().WithName("Açıklama");

            RuleFor(x => x.BrandId).GreaterThan(0).WithName("Marka");

            RuleFor(x => x.Price).GreaterThan(0).WithName("Fiyat");

            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithName("İndirim");

            RuleFor(x => x.CategoryIds).NotEmpty().Must(x => x.Any()).WithName("Kategoriler");
        }
    }
}
