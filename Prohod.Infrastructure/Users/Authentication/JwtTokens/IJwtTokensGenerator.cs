using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Users.Authentication.JwtTokens;

public interface IJwtTokensGenerator
{
    public JwtToken GenerateJwtToken(User user);
}