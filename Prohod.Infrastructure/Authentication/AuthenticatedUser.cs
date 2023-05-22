using Prohod.Domain.Users;
using Prohod.Infrastructure.Authentication.JwtTokens;

namespace Prohod.Infrastructure.Authentication;

public record AuthenticatedUser(User User, JwtToken Token);