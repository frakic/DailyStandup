using FluentValidation;

namespace DailyStandup.Contract.Spaces;
public class CreateUpdateSpaceDtoValidator : AbstractValidator<CreateUpdateSpaceDto>
{
    public CreateUpdateSpaceDtoValidator()
    {
        RuleFor(space => space.Name)
            .NotEmpty()
            .WithErrorCode("Space.NameRequired");
    }
}
