using ECommerce.Application.Bases;
using ECommerce.Application.Features.Products.Exceptions;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Interfaces.AutoMapper;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler :BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        //public IUnitOfWork _unitOfWork;
        public ProductRules _productRules;


     
        public CreateProductCommandHandler(ProductRules productRules, IOurMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
           // _unitOfWork = unitOfWork;
            _productRules = productRules;
        }


        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var isHaveProduct = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Title == request.Title);

            await _productRules.ProductTitleMustNotBeSame(isHaveProduct?.Title, request.Title);
           
            Product product = new(request.Title, request.Descriptipon, request.BrandId, request.Price, request.Discount);



            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if (await _unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new ProductCategory()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                }
                await _unitOfWork.SaveAsync();
            }
            return Unit.Value;
        }
    }
}
