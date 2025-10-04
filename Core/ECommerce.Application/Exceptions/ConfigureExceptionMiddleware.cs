using Microsoft.AspNetCore.Builder;

namespace ECommerce.Application.Exceptions
{
    public static class ConfigureExceptionMiddleware
    {
        public static async void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
