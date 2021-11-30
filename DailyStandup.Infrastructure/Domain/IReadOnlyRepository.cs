namespace DailyStandup.Infrastructure.Domain;

public interface IReadOnlyRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
{
    Task<TEntity> GetByIdAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);

    Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TKey> ids, bool includeDetails = true, CancellationToken cancellationToken = default);

    Task<IEnumerable<TEntity>> GetAllAsync(bool includeDetails = true, CancellationToken cancellationToken = default);
}

public interface IReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity, int> where TEntity : EntityBase<int> { }

