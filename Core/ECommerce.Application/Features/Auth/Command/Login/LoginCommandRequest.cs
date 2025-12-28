using MediatR;
using System.ComponentModel;

namespace ECommerce.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest :IRequest<LoginCommandResponse>
    {
        [DefaultValue("muharremyilmaz@mail.com")]
        public string Email { get; set; }
        [DefaultValue("12345678")]

        public string Password { get; set; }
    }
}
