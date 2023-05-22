using Microsoft.AspNetCore.Mvc;
using Prohod.Domain.ErrorsBase;
using Prohod.Domain.Users;

namespace Prohod.WebApi.Errors;

public class OperationErrorVisitor : IOperationErrorVisitor<ActionResult>
{
    public ActionResult Visit(UserNotFoundError error)
    {
        return ToError(StatusCodes.Status404NotFound, error.Message);
    }
    
    private static ActionResult ToError(int statusCode, string description)
    {
        return new ObjectResult(description) { StatusCode = statusCode };
    }
}