using Microsoft.EntityFrameworkCore;
using Serilog;

namespace PersonInformationGrpcService.Presentation.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception is DbUpdateException ? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError;

            var response = new
            {
                Message = "An error occurred.",
                Details = exception.Message
            };
            
            Log.Error($"Error: {response}");

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
