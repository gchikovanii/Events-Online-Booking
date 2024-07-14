using ItAcademy.Application.Infrastructure.Errors;
using Newtonsoft.Json;
using Serilog;

namespace ItAcademy.API.Infrastructure.Middleware.Exceptions
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }
        private static void HandleException(HttpContext context, Exception ex)
        {

            var error = new ApiErrors(context, ex);
            var jsonError = JsonConvert.SerializeObject(error);
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.Status.Value;
#pragma warning disable CA1305 // Specify IFormatProvider
            using (var res = new LoggerConfiguration().WriteTo.File(@"Logs\globalExceptions.txt").CreateLogger())
            {
                res.Information(jsonError);
            }
#pragma warning restore CA1305 // Specify IFormatProvider

        }
    }
}
