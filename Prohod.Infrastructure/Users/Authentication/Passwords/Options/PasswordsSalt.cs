namespace Prohod.Infrastructure.Users.Authentication.Passwords.Options;

public record PasswordsSalt
{
    public required string Value { get; init; }
}