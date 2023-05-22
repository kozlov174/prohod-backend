namespace Prohod.Domain.Users;

public record User(
    Guid Id, string Name, string Surname, string Login, string PasswordHash, string Email, Role Role);