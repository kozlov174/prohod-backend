using Prohod.Domain.ErrorsBase;

namespace Prohod.Domain.Users;

public record UserNotFoundError(string Message) : IOperationError
{
    public T Accept<T>(IOperationErrorVisitor<T> visitor) => visitor.Visit(this);
}