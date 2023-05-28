using AutoMapper;
using Prohod.Domain.Users;

namespace Prohod.WebApi.Users.Models.AutoMapperProfiles;

public class UserDtoProfile : Profile
{
    public UserDtoProfile()
    {
        CreateMap<User, UserDto>()
            .ForCtorParam(nameof(UserDto.Id), configuration => configuration.MapFrom(user => user.Id.Value))
            .ForCtorParam(nameof(UserDto.Name), configuration => configuration.MapFrom(user => user.Name.Value))
            .ForCtorParam(nameof(UserDto.Surname), configuration => configuration.MapFrom(user => user.Surname.Value))
            .ForCtorParam(nameof(UserDto.Login), configuration => configuration.MapFrom(user => user.Login.Value))
            .ForCtorParam(nameof(UserDto.UserEmail), configuration => configuration.MapFrom(user => user.Id.Value));
    }
}