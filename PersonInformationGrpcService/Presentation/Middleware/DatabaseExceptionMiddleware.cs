using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace PersonInformationGrpcService.Presentation.Middleware
{
    public class DatabaseExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateException dbEx)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Database connection error occurred. Please try again later.");

                Log.Error($"SQL Error: {dbEx.Message}");
            }
            catch (SqlException ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Database connection error occurred. Please try again later.");

                Log.Error($"SQL Error: {ex.Message}");
            }
        }
    }
}
