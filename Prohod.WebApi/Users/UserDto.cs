using Prohod.Domain.Users;

namespace Prohod.WebApi.Users;

public record UserDto(Guid Id, string Name, string Surname, string Login, string UserEmail, Role Role);