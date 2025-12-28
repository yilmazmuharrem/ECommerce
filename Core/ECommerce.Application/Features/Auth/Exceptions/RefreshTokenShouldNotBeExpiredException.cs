using ECommerce.Application.Bases;

namespace ECommerce.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir. Lütfen tekrar login olunuz") { }

    }

    public class EmailAdressShouldBeValidException : BaseException
    {
        public EmailAdressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır.") { }

    }
}
