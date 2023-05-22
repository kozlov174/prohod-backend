using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Users;

public record UserDbRepresentation(
    Guid Id, string Name, string Surname, string Login, string PasswordHash, string Email, Role Role);