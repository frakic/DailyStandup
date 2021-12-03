using DailyStandup.Api.Configurations;
using DailyStandup.Infrastructure.AspNetCore.Extensions;
using DailyStandup.Infrastructure.AspNetCore.Middlewares.Error;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true);

builder.Services.AddServices(builder.Configuration);

builder.Services.AddFluentValidationValidatorInterceptor();
builder.Services.AddExceptionHandlers();
builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorMiddleware>();

app.Run();
