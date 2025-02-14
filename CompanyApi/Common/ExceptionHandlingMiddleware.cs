using System.Net;
using System.Text.Json;

namespace CompanyApi.Common;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
            
        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message,
            Details = exception.InnerException?.Message
        };
        
        logger.LogError(exception.InnerException?.Message);

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}