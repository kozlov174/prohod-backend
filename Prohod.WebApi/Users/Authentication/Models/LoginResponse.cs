using Prohod.Infrastructure.Users.Authentication.JwtTokens;
using Prohod.WebApi.Users.Models;

namespace Prohod.WebApi.Users.Authentication.Models;

public record LoginResponse(UserDto User, JwtToken JwtToken);