using AutoMapper;
using ECommerce.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Mapper
{
    public  static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IOurMapper,AutoMapper.Mapper>();


        }
    }
}
