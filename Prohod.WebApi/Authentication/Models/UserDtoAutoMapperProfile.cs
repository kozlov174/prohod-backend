using AutoMapper;
using Prohod.Domain.Users;

namespace Prohod.WebApi.Authentication.Models;

public class UserDtoAutoMapperProfile : Profile
{
    public UserDtoAutoMapperProfile()
    {
        CreateMap<User, UserDto>();

        CreateMap<UserDto, User>();
    }
}