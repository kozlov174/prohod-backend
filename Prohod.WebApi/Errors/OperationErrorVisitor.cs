using Microsoft.AspNetCore.Mvc;
using Prohod.Domain.ErrorsBase;
using Prohod.Domain.RepositoriesBase;
using Prohod.Domain.Users.Errors;

namespace Prohod.WebApi.Errors;

public class OperationErrorVisitor : IOperationErrorVisitor<ActionResult>
{
    public ActionResult Visit<T>(EntityNotFound<T> error)
    {
        return ToError(StatusCodes.Status404NotFound, $"{typeof(T).Name} entity was not found");
    }

    public ActionResult Visit(UserToVisitWasNotFound error)
    {
        return ToError(StatusCodes.Status404NotFound, $"User to visit with id = {error.UserToVisitId} was not found");
    }

    private static ActionResult ToError(int statusCode, string description)
    {
        return new ObjectResult(description) { StatusCode = statusCode };
    }
}