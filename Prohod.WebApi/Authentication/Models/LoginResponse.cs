using Prohod.Infrastructure.Authentication.JwtTokens;

namespace Prohod.WebApi.Authentication.Models;

public record LoginResponse(UserDto User, JwtToken JwtToken);