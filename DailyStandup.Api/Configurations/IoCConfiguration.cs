using DailyStandup.Contract.Spaces;
using DailyStandup.Infrastructure.Domain;
using DailyStandup.Model.Spaces;
using DailyStandup.Repository;
using DailyStandup.Repository.Spaces;
using DailyStandup.Service.Spaces;
using Microsoft.EntityFrameworkCore;

namespace DailyStandup.Api.Configurations;
public static class IoCConfiguration
{
    private const string DailyStandupConnectionName = "DailyStandup";

    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureRepositories(services, configuration);
        ConfigureServices(services);
    }

    private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DailyStandupRepositoryContext>((provider, options) =>
        {
            options.UseNpgsql(configuration.GetConnectionString(DailyStandupConnectionName));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddTransient<ISpaceRepository, SpaceRepository>();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ISpaceService, SpaceService>();
    }
}
