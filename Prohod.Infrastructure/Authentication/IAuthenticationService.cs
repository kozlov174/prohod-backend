using Kontur.Results;
using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Authentication;

public interface IAuthenticationService
{
    public Task<Result<UserNotFoundError, AuthenticatedUser>> AuthenticateAsync(string login, string password);
}