using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DailyStandup.Infrastructure.AspNetCore.Middlewares.Error;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ExceptionHandlerFactory _exceptionHandlerFactory;

    public ErrorMiddleware(RequestDelegate next, ExceptionHandlerFactory exceptionHandlerFactory)
    {
        _next = next;
        _exceptionHandlerFactory = exceptionHandlerFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            var exceptionHandler = _exceptionHandlerFactory.Create(e);
            var errorDetails = exceptionHandler.Handle(e);
            errorDetails.RequestId = context.TraceIdentifier;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var errorDetailsJson = JsonSerializer.Serialize(errorDetails, errorDetails.GetType(), options);

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)errorDetails.Status;

            await response.WriteAsync(errorDetailsJson);
        }
    }
}