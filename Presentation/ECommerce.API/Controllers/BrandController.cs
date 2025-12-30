using ECommerce.Application.Features.Brands.Commands.CreateBrand;
using ECommerce.Application.Features.Brands.Queries.GetAllBrands;
using ECommerce.Application.Features.Products.Command.CreateProduct;
using ECommerce.Application.Features.Products.Command.DeleteProduct;
using ECommerce.Application.Features.Products.Command.UpdateProduct;
using ECommerce.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ECommerce.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;
        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
           var response = await mediator.Send(new GetAllBrandsQueryRequest());
            return Ok(response);
        }
    }
}
