using Prohod.Domain.RepositoriesBase;

namespace Prohod.Domain.ErrorsBase;

public interface IOperationErrorVisitor<out T>
{
    T Visit<TEntity>(EntityNotFound<TEntity> error);
}