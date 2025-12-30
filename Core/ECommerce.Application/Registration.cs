using ECommerce.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using ECommerce.Application.Behaviors;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Bases;
namespace ECommerce.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ExceptionMiddleware>();

            var assembly = Assembly.GetExecutingAssembly();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddTransient<ProductRules>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }
            return services;
        }
    }
}
