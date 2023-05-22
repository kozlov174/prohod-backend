using Kontur.Results;

namespace Prohod.Domain.Users;

public interface IUsersRepository
{
    public Task<Result<UserNotFoundError, User>> GetUserByLoginAndPasswordHash(string login, string passwordHash);
}