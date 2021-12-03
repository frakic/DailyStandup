using DailyStandup.Infrastructure.AspNetCore.Middlewares.Error;
using DailyStandup.Infrastructure.AspNetCore.Validation;
using DailyStandup.Infrastructure.Middlewares.Error;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace DailyStandup.Infrastructure.AspNetCore.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddFluentValidationValidatorInterceptor(this IServiceCollection services)
    {
        services.AddTransient<IValidatorInterceptor, FluentValidationValidatorInterceptor>();
    }

    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlerFactory, ExceptionHandlerFactory>();
        services.AddTransient<IExceptionHandler, DefaultExceptionHandler>();
        services.AddTransient<IExceptionHandler, FluentValidationValidationExceptionHandler>();
        services.AddTransient<IExceptionHandler, BusinessExceptionHandler>();
    }
}
