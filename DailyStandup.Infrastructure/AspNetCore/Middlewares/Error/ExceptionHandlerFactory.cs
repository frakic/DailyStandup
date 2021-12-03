using DailyStandup.Infrastructure.Middlewares.Error;

namespace DailyStandup.Infrastructure.AspNetCore.Middlewares.Error;

public class ExceptionHandlerFactory
{
    private readonly IEnumerable<IExceptionHandler> _exceptionHandlers;

    public ExceptionHandlerFactory(IEnumerable<IExceptionHandler> exceptionHandlers)
    {
        _exceptionHandlers = exceptionHandlers;
    }

    public IExceptionHandler Create(Exception e)
    {
        var defaultHandler = _exceptionHandlers.FirstOrDefault(eh => eh is DefaultExceptionHandler);
        var handler = _exceptionHandlers.FirstOrDefault(eh => eh != defaultHandler && eh.CanHandle(e));

        return handler ?? defaultHandler!;
    }
}