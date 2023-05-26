using Prohod.Domain.Users;
using Prohod.Infrastructure.Users.Authentication.JwtTokens;

namespace Prohod.Infrastructure.Users.Authentication;

public record AuthenticatedUser(User User, JwtToken Token);