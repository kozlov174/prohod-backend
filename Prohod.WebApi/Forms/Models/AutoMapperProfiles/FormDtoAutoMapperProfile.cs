using AutoMapper;
using Prohod.Domain.Forms;

namespace Prohod.WebApi.Forms.Models.AutoMapperProfiles;

public class FormDtoAutoMapperProfile : Profile
{
    public FormDtoAutoMapperProfile()
    {
        CreateMap<FormDto, Form>();
    }
}