using Prohod.Domain.GenericRepository;
using Prohod.Infrastructure.Database;

namespace Prohod.WebApi.Configuration;

public static class GenericRepositoryRegistrar
{
    public static IServiceCollection AddGenericRepository(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}