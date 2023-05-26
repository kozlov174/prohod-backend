namespace Prohod.Infrastructure.Users.Authentication.Passwords;

public interface IPasswordsHashCalculator
{
    public string CalculatePasswordHash(string password);
}