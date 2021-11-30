using DailyStandup.Infrastructure.Domain;

namespace DailyStandup.Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly DailyStandupRepositoryContext _context;
    public UnitOfWork(DailyStandupRepositoryContext context)
    {
        _context = context;
    }
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}

