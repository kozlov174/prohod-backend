using AutoMapper;
using Prohod.Domain.VisitRequests.Forms;
using Prohod.WebApi.VisitRequests.Models.Dto;

namespace Prohod.WebApi.VisitRequests.Models.AutoMapperProfiles;

public class FormAggregationDtoProfile : Profile
{
    public FormAggregationDtoProfile()
    {
        CreateMap<Form, FormAggregatedDto>();
    }
}