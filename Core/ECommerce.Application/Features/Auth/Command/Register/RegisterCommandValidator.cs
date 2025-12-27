using FluentValidation;

namespace ECommerce.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(50).MinimumLength(2).WithName("İsim Soyisim");
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress().MinimumLength(8).WithName("E posta adresi");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithName("Parola");
            RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(8).Equal(x=>x.Password).WithName("Parola Tekrarı");

        }
    }
}
