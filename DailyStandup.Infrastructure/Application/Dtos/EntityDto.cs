namespace DailyStandup.Infrastructure.Application.Dtos;
public class EntityDto<TKey>
{
    public TKey Id { get; set; } = default!;
}

public class EntityDto : EntityDto<int>
{
}