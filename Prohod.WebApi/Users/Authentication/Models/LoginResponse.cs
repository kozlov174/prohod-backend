using Prohod.Infrastructure.Users.Authentication.JwtTokens;
using Prohod.WebApi.Users.Models;

namespace Prohod.WebApi.Users.Authentication.Models;

public record LoginResponse(UserResponseDto UserResponse, JwtToken JwtToken);