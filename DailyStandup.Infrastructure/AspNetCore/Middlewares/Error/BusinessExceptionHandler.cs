using DailyStandup.Infrastructure.Domain;
using DailyStandup.Infrastructure.Middlewares.Error;
using System.Net;

namespace DailyStandup.Infrastructure.AspNetCore.Middlewares.Error;

public class BusinessExceptionHandler : IExceptionHandler
{
    public bool CanHandle(Exception e)
    {
        return e is BusinessException;
    }

    public ErrorDetails Handle(Exception e)
    {
        var businessException = e as BusinessException;

        var errorDetails = new CodeErrorDetails("Business error occured",
            HttpStatusCode.BadRequest,
            businessException?.Code,
            businessException?.Message);

        return errorDetails;
    }
}
