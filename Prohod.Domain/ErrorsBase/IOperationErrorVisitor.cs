using Prohod.Domain.GenericRepository;
using Prohod.Domain.Users.Errors;

namespace Prohod.Domain.ErrorsBase;

public interface IOperationErrorVisitor<out T>
{
    T Visit<TEntity>(EntityNotFound<TEntity> error);

    T Visit(UserToVisitWasNotFound error);
}