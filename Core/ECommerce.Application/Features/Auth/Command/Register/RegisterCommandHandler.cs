using ECommerce.Application.Bases;
using ECommerce.Application.Features.Auth.Rules;
using ECommerce.Application.Interfaces.AutoMapper;
using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules _authRules;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IOurMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _authRules = authRules;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }


        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _authRules.UserShouldNotBeExist(await _userManager.FindByEmailAsync(request.Email));

            User user = _mapper.Map<User, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp=Guid.NewGuid().ToString();

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("user"))
                {
                    await _roleManager.CreateAsync(new Role
                    {
                        Id = new Guid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                    await _userManager.AddToRoleAsync(user, "user");
                }

               
            }

            return Unit.Value;
            throw new NotImplementedException();
        }
    }
}
