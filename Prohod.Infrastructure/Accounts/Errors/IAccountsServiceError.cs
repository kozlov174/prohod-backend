namespace Prohod.Infrastructure.Accounts.Errors;

public interface IAccountsServiceError
{
    public T Accept<T>(IAccountsServiceErrorVisitor<T> visitor);
}