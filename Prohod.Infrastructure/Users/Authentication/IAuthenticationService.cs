using Kontur.Results;
using Prohod.Domain.RepositoriesBase;
using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Users.Authentication;

public interface IAuthenticationService
{
    public Task<Result<EntityNotFound<User>, AuthenticatedUser>> AuthenticateAsync(string login, string password);
}