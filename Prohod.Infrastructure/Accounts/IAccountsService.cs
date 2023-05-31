using Kontur.Results;
using Prohod.Domain.GenericRepository;
using Prohod.Domain.Users;
using Prohod.Infrastructure.Accounts.Models;

namespace Prohod.Infrastructure.Accounts;

public interface IAccountsService
{
    public Task<Result<EntityNotFoundError<Account>, AuthenticatedUser>> AuthenticateAsync(
        string login, string password);
}