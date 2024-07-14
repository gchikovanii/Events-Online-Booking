using ItAcademy.API.Infrastructure.Middleware.Culture;

namespace ItAcademy.API.Infrastructure.Extensions.Culture
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureConfigMiddleware>();
        }
    }
}
