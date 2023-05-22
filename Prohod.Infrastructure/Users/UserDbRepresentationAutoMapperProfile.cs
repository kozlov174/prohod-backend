using AutoMapper;
using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Users;

public class UserDbRepresentationAutoMapperProfile : Profile
{
    public UserDbRepresentationAutoMapperProfile()
    {
        CreateMap<UserDbRepresentation, User>();

        CreateMap<User, UserDbRepresentation>();
    }
}