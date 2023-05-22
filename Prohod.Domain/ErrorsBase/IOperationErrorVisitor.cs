using Prohod.Domain.Users;

namespace Prohod.Domain.ErrorsBase;

public interface IOperationErrorVisitor<out T>
{
    T Visit(UserNotFoundError error);
}