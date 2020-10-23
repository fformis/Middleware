using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Middleware{
    public class CustomMiddleware{
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        private readonly ILogger<CustomMiddleware> _logger;
        public async Task Invoke(HttpContext context)
        {
            _logger.LogError("Chamou nosso middleware (antes)");
            await _next(context);
            _logger.LogError("Chamou nosso middleware (depois)");
        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }

}