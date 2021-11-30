using DailyStandup.Model.Spaces;
using Microsoft.EntityFrameworkCore;

namespace DailyStandup.Repository;

public class DailyStandupRepositoryContext : DbContext
{
    public DailyStandupRepositoryContext(DbContextOptions<DailyStandupRepositoryContext> options) : base(options) { }

    public DbSet<Space> Spaces => Set<Space>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DailyStandupRepositoryContext).Assembly);
    }
}