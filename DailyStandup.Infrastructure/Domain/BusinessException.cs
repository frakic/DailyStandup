namespace DailyStandup.Infrastructure.Domain;

public class BusinessException : Exception
{
    public string? Code { get; private set; }

    public BusinessException(string message, string? code = null) : base(message)
    {
        Code = code;
    }
}
