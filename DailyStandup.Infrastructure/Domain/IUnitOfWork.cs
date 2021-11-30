namespace DailyStandup.Infrastructure.Domain;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}