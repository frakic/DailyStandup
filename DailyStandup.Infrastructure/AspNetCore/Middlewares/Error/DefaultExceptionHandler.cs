using System.Net;

namespace DailyStandup.Infrastructure.Middlewares.Error;

public class DefaultExceptionHandler : IExceptionHandler
{
    public bool CanHandle(Exception e)
    {
        return true;
    }

    public ErrorDetails Handle(Exception e)
    {
        var errorDetails = new ErrorDetails("Error occured", HttpStatusCode.InternalServerError);

        return errorDetails;
    }
}