namespace DailyStandup.Contract.Spaces;

public interface ISpaceService
{
    Task CreateAsync(CreateUpdateSpaceDto input);
}

