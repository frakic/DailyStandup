using DailyStandup.Infrastructure.EntityFrameworkCore;
using DailyStandup.Model.Spaces;

namespace DailyStandup.Repository.Spaces;

public class SpaceRepository : EntityFrameworkCoreRepository<DailyStandupRepositoryContext, Space>, ISpaceRepository
{
    public SpaceRepository(DailyStandupRepositoryContext context) : base(context) { }
}

