using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.AutoMapper;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOurMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IOurMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));


            var brand = mapper.Map<BrandDto, Brand>(new Brand());
            var maps = mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in maps)
            {
                item.Price -= (item.Price * item.Discount / 100);
            }
            return maps;
        }
    }
}
