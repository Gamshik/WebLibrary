using Domain.Classes.Entities;
using Domain.Interfaces;
using System.Net;

namespace WebApi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandlerExceptionMessageAsync(context, ex, _logger);
            }
        }
        private static async Task HandlerExceptionMessageAsync(HttpContext context, Exception exception, ILoggerService logger)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            logger.LogError("Something went wrong: " + exception.Message);

            await context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = statusCode,
                Message = "Internal server error"
            }.ToString());
        }
    }
}
