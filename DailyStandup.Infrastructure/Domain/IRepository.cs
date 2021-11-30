namespace DailyStandup.Infrastructure.Domain;

public interface IRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
{
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}

public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : EntityBase<int> { }
