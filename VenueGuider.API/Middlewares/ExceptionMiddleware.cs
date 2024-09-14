using System.Net;

namespace VenueGuider.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(ex);;

            var response = new
            {
                Message = "An unexpected error occurred.",
                Detail = ex.Message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
    
    private static int GetStatusCode(Exception ex)
    {
        if (ex is KeyNotFoundException)
            return (int)HttpStatusCode.NotFound;
        if (ex is UnauthorizedAccessException)
            return (int)HttpStatusCode.Unauthorized;
        if (ex is ArgumentException)
            return (int)HttpStatusCode.BadRequest;
        return (int)HttpStatusCode.InternalServerError;
    }
}