using Kontur.Results;
using Prohod.Domain.GenericRepository;
using Prohod.Domain.Users;
using Prohod.Infrastructure.Accounts.Models;

namespace Prohod.Infrastructure.Accounts.Repository;

public interface IAccountsRepository : IRepository<Account>
{
    public Task<Result<EntityNotFoundError<Account>, User>> GetUserByLoginAndPassword(
        string login, string passwordsHash);

    public Task<bool> IsLoginExists(string login);
}