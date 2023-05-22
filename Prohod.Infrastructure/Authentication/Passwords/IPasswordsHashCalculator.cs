namespace Prohod.Infrastructure.Authentication.Passwords;

public interface IPasswordsHashCalculator
{
    public string CalculatePasswordHash(string password);
}