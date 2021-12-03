using FluentValidation;
using System.Net;

namespace DailyStandup.Infrastructure.Middlewares.Error;

public class FluentValidationValidationExceptionHandler : IExceptionHandler
{
    public bool CanHandle(Exception e)
    {
        return e is ValidationException;
    }

    public ErrorDetails Handle(Exception e)
    {
        var validationException = e as ValidationException;
        var validationErrors = new List<ValidationError>();

        if (validationException?.Errors is not null)
        {
            foreach (var validationFailure in validationException.Errors)
            {
                var validationError = new ValidationError(validationFailure.PropertyName,
                    validationFailure.ErrorCode,
                    validationFailure.ErrorMessage);

                validationErrors.Add(validationError);
            }
        }

        var errorDetails = new ValidationErrorDetails("One or more validation errors occured",
            HttpStatusCode.BadRequest,
            validationErrors);

        return errorDetails;
    }
}