using ECommerce.Application.Bases;
using ECommerce.Application.Features.Auth.Exceptions;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Auth.Rules
{
    public class AuthRules :BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null)
            {
                throw new UserAlreadyExistException();
            }
            return Task.CompletedTask;
        }


        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkpassword)
        {
            if (user is null || !checkpassword)
            {
                throw new EmailOrPasswordShouldNotBeInvalidException();
            }
            return Task.CompletedTask;

        }



        public Task RefreshTokenShouldNotBeExpired(DateTime? expiryDate)
        {

            if (expiryDate <= DateTime.Now)
            {
                throw new RefreshTokenShouldNotBeExpiredException();
            }

            return Task.CompletedTask;

        }


        public Task EmailAdressShouldBeValid(User? user)
        {

            if (user is null)
            {
                throw new EmailAdressShouldBeValidException();
            }

            return Task.CompletedTask;

        }
    }
}
