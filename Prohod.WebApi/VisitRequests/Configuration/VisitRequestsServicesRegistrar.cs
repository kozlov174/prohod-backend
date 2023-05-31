using Prohod.Domain.VisitRequests;
using Prohod.Infrastructure.VisitRequests;

namespace Prohod.WebApi.VisitRequests.Configuration;

public static class VisitRequestsServicesRegistrar
{
    public static IServiceCollection AddVisitRequestsServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IVisitRequestsRepository, VisitRequestsRepository>()
            .AddScoped<IVisitRequestsService, VisitRequestsService>();
    } 
}