namespace Prohod.Infrastructure.Accounts.Models.CreateAccount;

public interface IAccountsServiceErrorVisitor<out T>
{
    public T Visit(LoginAlreadyExistsError error);
}