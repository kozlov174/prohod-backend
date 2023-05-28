using Microsoft.EntityFrameworkCore;
using Prohod.Infrastructure.Database;

namespace Prohod.WebApi.Configuration;

public static class PostgresDbContextRegistrar
{
    private const string PostgresConnectionStringName = "PostgreSql";

    public static IServiceCollection AddPostgresDbContext(
        this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection
            .AddDbContext<PostgresDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString(PostgresConnectionStringName)))
            .AddScoped<IAppDbContext, PostgresDbContext>();
    }
}