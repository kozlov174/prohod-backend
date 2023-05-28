using AutoMapper;
using Prohod.Domain.VisitRequests.Forms;
using Prohod.WebApi.VisitRequests.Models.Forms;

namespace Prohod.WebApi.VisitRequests.Models.AutoMapperProfiles;

public class FormAggregatedDtoProfile : Profile
{
    public FormAggregatedDtoProfile()
    {
        CreateMap<FormAggregated, FormAggregatedDto>()
            .ForCtorParam(
                nameof(FormAggregatedDto.Id),
                configuration => configuration.MapFrom(form => form.Id.Value))
            .ForCtorParam(
                nameof(FormAggregatedDto.Passport),
                configuration => configuration.MapFrom(form => form.Passport))
            .ForCtorParam(
                nameof(FormAggregatedDto.VisitTime),
                configuration => configuration.MapFrom(form => form.VisitTime.Value))
            .ForCtorParam(
                nameof(FormAggregatedDto.VisitReason),
                configuration => configuration.MapFrom(form => form.VisitReason.Value))
            .ForCtorParam(
                nameof(FormAggregatedDto.UserToVisit),
                configuration => configuration.MapFrom(form => form.UserToVisit))
            .ForCtorParam(
                nameof(FormAggregatedDto.EmailToSendReply),
                configuration => configuration.MapFrom(form => form.EmailToSendReply.Value));
    }
}