using Prohod.Domain.ErrorsBase;

namespace Prohod.Domain.Users.Errors;

public record UserToVisitWasNotFound(UserId UserToVisitId) : IApplyFormError
{
    public T Accept<T>(IOperationErrorVisitor<T> visitor) => visitor.Visit(this);
}