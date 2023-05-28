using AutoMapper;
using Prohod.WebApi.Users.Models.AutoMapperProfiles;
using Prohod.WebApi.VisitRequests.Models.AutoMapperProfiles;

namespace Prohod.WebApi.Configuration;

public static class AutoMapperRegistrar
{
    public static IServiceCollection AddAutoMapperWithProfiles(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddAutoMapper(
            configuration => configuration
                .AddProfiles(new Profile[]
                {
                    new FormAggregatedDtoProfile(),
                    new FormDtoProfile(),
                    new UserDtoProfile(),
                    new VisitRequestAggregatedProfile(),
                    new PassportDtoProfile(),
                }));
    }
}