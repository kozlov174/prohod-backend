namespace Prohod.Infrastructure.Accounts.Passwords;

public interface IPasswordsHashCalculator
{
    public string CalculatePasswordHash(string password);
}