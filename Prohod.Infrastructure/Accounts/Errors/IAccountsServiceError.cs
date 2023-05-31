namespace Prohod.Infrastructure.Accounts.Models.CreateAccount;

public interface IAccountsServiceError
{
    public T Accept<T>(IAccountsServiceErrorVisitor<T> visitor);
}