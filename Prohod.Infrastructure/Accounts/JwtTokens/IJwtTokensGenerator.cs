using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Accounts.JwtTokens;

public interface IJwtTokensGenerator
{
    public JwtToken GenerateJwtToken(User user);
}