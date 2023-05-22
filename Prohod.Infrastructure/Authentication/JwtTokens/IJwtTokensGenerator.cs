using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Authentication.JwtTokens;

public interface IJwtTokensGenerator
{
    public JwtToken GenerateJwtToken(User user);
}