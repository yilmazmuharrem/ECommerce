using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ECommerce.API.Middlewares
{
    public class ExceptionHandling
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandling> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500; 

                var response = new ProblemDetails
                {
                    Title = "An error occurred while processing your request.",
                    Detail = _env.IsDevelopment() ? ex.Message : "An unexpected error occurred.",
                    Status = context.Response.StatusCode,
                    Instance = context.Request.Path
                };
                var options = new JsonSerializerOptions { PropertyNamingPolicy=JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
