namespace DailyStandup.Infrastructure.Domain;
public abstract class EntityBase<TId>
{
    public TId Id { get; protected set; } = default!;
}

public class EntityBase : EntityBase<int> { }