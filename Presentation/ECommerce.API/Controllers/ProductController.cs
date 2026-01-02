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
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        // Bu endpoint role çalışmalarına yönelik test amaclı yazılmıştır.

        [HttpGet]   
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllProductsAdmin()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "user,Admin")]
        public async Task<IActionResult> GetAllProductsUser()
        {

            var x = User;
            var response = await mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductCommandRequest request)
        {
             await mediator.Send(request);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProducts(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteProducts(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
