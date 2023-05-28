using System.Linq.Expressions;
using Kontur.Results;

namespace Prohod.Domain.RepositoriesBase;

public interface IRepository<T>
{
    public Task AddAsync(T entity);

    public Task<Result<EntityNotFound<T>, T>> SingleAsync(Expression<Func<T, bool>> specification);

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> specification);

    public Task<IReadOnlyCollection<T>> GetPage<TOrderProperty>(
        Expression<Func<T, TOrderProperty>> orderPropertySelector, int offset, int limit);
}