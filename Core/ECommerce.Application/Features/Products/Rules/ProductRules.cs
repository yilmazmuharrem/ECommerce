using ECommerce.Application.Bases;
using ECommerce.Application.Features.Products.Exceptions;

namespace ECommerce.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(string? requestTitle, string productTitle)
        {

            if (requestTitle == productTitle) throw new ProductTitleMustNotBeSameException();

            return Task.CompletedTask;
        }
    }
}
