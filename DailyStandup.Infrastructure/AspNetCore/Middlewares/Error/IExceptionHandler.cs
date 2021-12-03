namespace DailyStandup.Infrastructure.Middlewares.Error;

public interface IExceptionHandler
{
    public bool CanHandle(Exception e);
    public ErrorDetails Handle(Exception e);
}

