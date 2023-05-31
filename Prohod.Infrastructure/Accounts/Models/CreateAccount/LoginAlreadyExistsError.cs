using Prohod.Domain.ErrorsBase;

namespace Prohod.Infrastructure.Accounts.Models.CreateAccount;

public record LoginAlreadyExistsError(string Login) : IAccountsServiceError
{
    public T Accept<T>(IAccountsServiceErrorVisitor<T> visitor) => visitor.Visit(this);
}