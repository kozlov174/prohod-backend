using AutoMapper;
using Prohod.Domain.VisitRequests.Forms;
using Prohod.WebApi.VisitRequests.Models.Forms;

namespace Prohod.WebApi.VisitRequests.Models.AutoMapperProfiles;

public class PassportDtoProfile : Profile
{
    public PassportDtoProfile()
    {
        CreateMap<Passport, PassportDto>()
            .ForCtorParam(
                nameof(PassportDto.FullName),
                configuration => configuration.MapFrom(dto => dto.FullName.Value))
            .ForCtorParam(
                nameof(PassportDto.Series),
                configuration => configuration.MapFrom(dto => dto.Series.Value))
            .ForCtorParam(
                nameof(PassportDto.Number),
                configuration => configuration.MapFrom(dto => dto.Number.Value))
            .ForCtorParam(
                nameof(PassportDto.WhoIssued),
                configuration => configuration.MapFrom(dto => dto.WhoIssued.Value))
            .ForCtorParam(
                nameof(PassportDto.IssueDate),
                configuration => configuration.MapFrom(dto => dto.IssueDate.Value));
    }
}