using AutoMapper;
using Prohod.Domain.VisitRequests;
using Prohod.WebApi.VisitRequests.Models.GetAllVisitRequestsPage;
using Prohod.WebApi.VisitRequests.Models.GetNotProcessedVisitRequestsPage;
using Prohod.WebApi.VisitRequests.Models.GetUserProcessedVisitRequestsPage;

namespace Prohod.WebApi.VisitRequests.Models.AutoMapperProfiles;

public class VisitRequestAggregatedProfile : Profile
{
    public VisitRequestAggregatedProfile()
    {
        CreateMap<VisitRequestAggregated, NotProcessedVisitRequestAggregatedDto>()
            .ForCtorParam(
                nameof(NotProcessedVisitRequestAggregatedDto.Id),
                configuration => configuration.MapFrom(request => request.Id.Value))
            .ForCtorParam(
                nameof(NotProcessedVisitRequestAggregatedDto.Form),
                configuration => configuration.MapFrom(request => request.Form));

        CreateMap<VisitRequestAggregated, VisitRequestAggregatedDto>()
            .ForCtorParam(
                nameof(VisitRequestAggregatedDto.Id),
                configuration => configuration.MapFrom(request => request.Id.Value))
            .ForCtorParam(
                nameof(VisitRequestAggregatedDto.Form),
                configuration => configuration.MapFrom(request => request.Form))
            .ForCtorParam(
                nameof(VisitRequestAggregatedDto.WhoProcessed),
                configuration => configuration.MapFrom(request => request.WhoProcessed))
            .ForCtorParam(
                nameof(VisitRequestAggregatedDto.RejectionReason),
                configuration => configuration.MapFrom(request => request.RejectionReason!.Value));
        
        CreateMap<VisitRequestAggregated, UserProcessedVisitRequestAggregatedDto>()
            .ForCtorParam(
                nameof(UserProcessedVisitRequestAggregatedDto.Id),
                configuration => configuration.MapFrom(request => request.Id.Value))
            .ForCtorParam(
                nameof(UserProcessedVisitRequestAggregatedDto.Form),
                configuration => configuration.MapFrom(request => request.Form))
            .ForCtorParam(
                nameof(UserProcessedVisitRequestAggregatedDto.WhoProcessed),
                configuration => configuration.MapFrom(request => request.WhoProcessed))
            .ForCtorParam(
                nameof(UserProcessedVisitRequestAggregatedDto.RejectionReason),
                configuration => configuration.MapFrom(request => request.RejectionReason!.Value));
    }
}