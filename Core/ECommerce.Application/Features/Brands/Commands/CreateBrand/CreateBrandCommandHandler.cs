using Bogus;
using ECommerce.Application.Bases;
using ECommerce.Application.Interfaces.AutoMapper;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, Unit>
    {
        public CreateBrandCommandHandler(IOurMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new("tr");
            List<Brand> brands = new List<Brand>();
            for (int i = 0; i < 100000; i++)
            {
                brands.Add(new(faker.Commerce.Department(1)));
            }
            await _unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
