using AutoMapper;
using Prohod.Domain.Forms;

namespace Prohod.WebApi.Forms.Models.AutoMapperProfiles;

public class FormDtoAutoMapperProfile : Profile
{
    public FormDtoAutoMapperProfile()
    {
        CreateMap<FormDto, Form>()
            .ForMember(form => form.Passport, options => options
                .MapFrom(dto => 
                    new Passport(
                        new(dto.FullName),
                        new(dto.PassportSeries),
                        new(dto.PassportNumber),
                        new(dto.WhoIssued),
                        new(dto.IssueDate))));
    }
}