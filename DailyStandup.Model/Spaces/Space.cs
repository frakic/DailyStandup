using DailyStandup.Infrastructure.Domain;

namespace DailyStandup.Model.Spaces;

public class Space : AuditEntity
{
    public string Name { get; private set; }

    public Space(string name)
    {
        Name = name;
    }
}