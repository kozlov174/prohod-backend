using Prohod.Domain.Users;

namespace Prohod.WebApi.Users.Models;

public record UserDto(string Name, string Surname, string Login, string Email, Role Role);