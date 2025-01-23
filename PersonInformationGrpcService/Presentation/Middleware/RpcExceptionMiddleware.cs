using Grpc.Core;
using Serilog;

namespace PersonInformationGrpcService.Presentation.Middleware
{
    public class RpcExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public RpcExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RpcException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, RpcException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

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
