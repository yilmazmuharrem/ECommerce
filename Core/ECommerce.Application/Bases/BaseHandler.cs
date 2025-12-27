using ECommerce.Application.Interfaces.AutoMapper;
using ECommerce.Application.Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ECommerce.Application.Bases
{
    public class BaseHandler
    {


        protected readonly IOurMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly string _userId;
        public BaseHandler(IOurMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
