using AutoMapper;
using Prohod.Domain.Users;

namespace Prohod.WebApi.Users.Models.AutoMapperProfiles;

public class UserDtoProfile : Profile
{
    public UserDtoProfile()
    {
        CreateMap<User, UserResponseDto>();
    }
}