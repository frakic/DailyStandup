namespace DailyStandup.Contract.Spaces;

public interface ISpaceService
{
    Task CreateAsync(CreateSpaceDto input);
}

