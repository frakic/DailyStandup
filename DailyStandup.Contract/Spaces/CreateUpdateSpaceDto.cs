using DailyStandup.Infrastructure.Application.Dtos;

namespace DailyStandup.Contract.Spaces;

public class CreateUpdateSpaceDto : EntityDto
{
    public string? Name { get; set; }
}