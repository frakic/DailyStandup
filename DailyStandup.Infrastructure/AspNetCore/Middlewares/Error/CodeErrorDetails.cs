using DailyStandup.Infrastructure.Middlewares.Error;
using System.Net;

namespace DailyStandup.Infrastructure.AspNetCore.Middlewares.Error;

public class CodeErrorDetails : ErrorDetails
{
    public string? Code { get; private set; }
    public string? Error { get; private set; }
    public CodeErrorDetails(string title, HttpStatusCode httpStatusCode,
        string? code, string? error) : base(title, httpStatusCode)
    {
        Code = code;
        Error = error;
    }
}