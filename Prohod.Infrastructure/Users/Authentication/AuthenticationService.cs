using Kontur.Results;
using Prohod.Domain.RepositoriesBase;
using Prohod.Domain.Users;
using Prohod.Infrastructure.Users.Authentication.JwtTokens;
using Prohod.Infrastructure.Users.Authentication.Passwords;

namespace Prohod.Infrastructure.Users.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepository<User> usersRepository;
    private readonly IPasswordsHashCalculator passwordsHashCalculator;
    private readonly IJwtTokensGenerator jwtTokensGenerator;

    public AuthenticationService(
        IRepository<User> usersRepository,
        IPasswordsHashCalculator passwordsHashCalculator,
        IJwtTokensGenerator jwtTokensGenerator)
    {
        this.usersRepository = usersRepository;
        this.passwordsHashCalculator = passwordsHashCalculator;
        this.jwtTokensGenerator = jwtTokensGenerator;
    }

    public async Task<Result<EntityNotFound<User>, AuthenticatedUser>> AuthenticateAsync(string login, string password)
    {
        var passwordHash = passwordsHashCalculator.CalculatePasswordHash(password); 
        var getUserResult = await usersRepository.SingleAsync(
            userInDb => userInDb.Login == new Login(login) && userInDb.PasswordHash == new PasswordHash(passwordHash));

        if (!getUserResult.TryGetValue(out var user, out var fault))
        {
            return fault;
        }

        var jwtToken = jwtTokensGenerator.GenerateJwtToken(user);
        
        return new AuthenticatedUser(user, jwtToken);
    }
}