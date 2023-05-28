using Prohod.Domain.Users;

namespace Prohod.WebApi.Users.Models;

public record UserDto(Guid Id, string Name, string Surname, string Login, string UserEmail, Role Role);