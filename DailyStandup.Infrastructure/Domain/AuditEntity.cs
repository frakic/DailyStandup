namespace DailyStandup.Infrastructure.Domain;
public class AuditEntity<T> : EntityBase<T>
{
    protected AuditEntity() { }
}

public class AuditEntity : AuditEntity<int> { }
