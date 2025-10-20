using ECommerce.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using ECommerce.Application.Behaviors;
namespace ECommerce.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ExceptionMiddleware>();
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture=new System.Globalization.CultureInfo("tr");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }
    }
}
