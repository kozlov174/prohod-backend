using Kontur.Results;
using Prohod.Domain.Users;
using Prohod.Infrastructure.Authentication.JwtTokens;
using Prohod.Infrastructure.Authentication.Passwords;

namespace Prohod.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUsersRepository usersRepository;
    private readonly IPasswordsHashCalculator passwordsHashCalculator;
    private readonly IJwtTokensGenerator jwtTokensGenerator;

    public AuthenticationService(
        IUsersRepository usersRepository,
        IPasswordsHashCalculator passwordsHashCalculator,
        IJwtTokensGenerator jwtTokensGenerator)
    {
        this.usersRepository = usersRepository;
        this.passwordsHashCalculator = passwordsHashCalculator;
        this.jwtTokensGenerator = jwtTokensGenerator;
    }

    public async Task<Result<UserNotFoundError, AuthenticatedUser>> AuthenticateAsync(string login, string password)
    {
        var passwordHash = passwordsHashCalculator.CalculatePasswordHash(password);
        var getUserResult = await usersRepository.GetUserByLoginAndPasswordHash(login, passwordHash);

        if (!getUserResult.TryGetValue(out var user, out var fault))
        {
            return fault;
        }

        var jwtToken = jwtTokensGenerator.GenerateJwtToken(user);
        
        return new AuthenticatedUser(user, jwtToken);
    }
}