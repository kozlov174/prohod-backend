using AutoMapper;
using Prohod.Domain.VisitRequests.Forms;
using Prohod.WebApi.VisitRequests.Models.Forms;

namespace Prohod.WebApi.VisitRequests.Models.AutoMapperProfiles;

public class FormDtoProfile : Profile
{
    public FormDtoProfile()
    {
        CreateMap<FormDto, Form>();
    }
}