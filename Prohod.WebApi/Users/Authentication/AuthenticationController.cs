using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prohod.Domain.ErrorsBase;
using Prohod.Infrastructure.Users.Authentication;
using Prohod.WebApi.Users.Authentication.Models;
using Prohod.WebApi.Users.Models;

namespace Prohod.WebApi.Users.Authentication;

[Route("/api/v1/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService authenticationService;
    private readonly IOperationErrorVisitor<ActionResult> errorsVisitor;
    private readonly IMapper mapper;

    public AuthenticationController(
        IAuthenticationService authenticationService,
        IOperationErrorVisitor<ActionResult> errorsVisitor,
        IMapper mapper)
    {
        this.authenticationService = authenticationService;
        this.errorsVisitor = errorsVisitor;
        this.mapper = mapper;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var (login, password) = request;
        var getUserResult = await authenticationService.AuthenticateAsync(login, password);

        if (!getUserResult.TryGetValue(out var authenticatedUser, out var fault))
        {
            return fault.Accept(errorsVisitor);
        }
        
        return new LoginResponse(mapper.Map<UserDto>(authenticatedUser.User), authenticatedUser.Token);
    }
}