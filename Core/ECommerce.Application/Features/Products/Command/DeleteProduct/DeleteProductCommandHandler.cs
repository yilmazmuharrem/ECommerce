using ECommerce.Application.Bases;
using ECommerce.Application.Interfaces.AutoMapper;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler :BaseHandler, IRequestHandler<DeleteProductCommandRequest,Unit>
    {
     
        public DeleteProductCommandHandler(IOurMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            // _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            product.IsDeleted = true;
            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
