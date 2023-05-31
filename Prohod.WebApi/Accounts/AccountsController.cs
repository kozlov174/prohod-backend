using Microsoft.AspNetCore.Mvc;
using Prohod.Domain.ErrorsBase;
using Prohod.Infrastructure.Accounts;
using Prohod.WebApi.Accounts.Models.Login;

namespace Prohod.WebApi.Accounts;

[Route("/api/v1/accounts")]
public class AccountsController : ControllerBase
{
    private readonly IAccountsService accountsService;
    private readonly IOperationErrorVisitor<ActionResult> errorsVisitor;

    public AccountsController(
        IAccountsService accountsService,
        IOperationErrorVisitor<ActionResult> errorsVisitor)
    {
        this.accountsService = accountsService;
        this.errorsVisitor = errorsVisitor;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var (login, password) = request;
        var getUserResult = await accountsService.AuthenticateAsync(login, password);

        if (!getUserResult.TryGetValue(out var authenticatedUser, out var fault))
        {
            return fault.Accept(errorsVisitor);
        }
        
        return new LoginResponse(authenticatedUser.User, authenticatedUser.Token);
    }
}