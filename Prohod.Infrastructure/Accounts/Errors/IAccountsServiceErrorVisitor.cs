using Prohod.Infrastructure.Accounts.Models.CreateAccount;

namespace Prohod.Infrastructure.Accounts.Errors;

public interface IAccountsServiceErrorVisitor<out T>
{
    public T Visit(LoginAlreadyExistsError error);
}