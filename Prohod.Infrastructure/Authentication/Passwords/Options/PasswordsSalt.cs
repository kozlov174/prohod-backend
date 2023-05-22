namespace Prohod.Infrastructure.Authentication.Passwords.Options;

public record PasswordsSalt
{
    public required string Value { get; init; }
}