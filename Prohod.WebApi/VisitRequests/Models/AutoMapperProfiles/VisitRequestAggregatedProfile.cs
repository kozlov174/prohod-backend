using AutoMapper;
using Prohod.Domain.VisitRequests;
using Prohod.WebApi.VisitRequests.Models.Dto;

namespace Prohod.WebApi.VisitRequests.Models.AutoMapperProfiles;

public class VisitRequestAggregatedProfile : Profile
{
    public VisitRequestAggregatedProfile()
    {
        CreateMap<VisitRequestAggregated, NotProcessedVisitRequestAggregatedDto>();

        CreateMap<VisitRequestAggregated, VisitRequestAggregatedDto>();
        
        CreateMap<VisitRequestAggregated, UserProcessedVisitRequestAggregatedDto>();
    }
}