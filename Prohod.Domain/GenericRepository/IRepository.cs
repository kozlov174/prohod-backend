using Kontur.Results;
using Prohod.Domain.AggregationRoot;

namespace Prohod.Domain.GenericRepository;

public interface IRepository<T> where T : IAggregationRoot
{
    public Task AddAsync(T entity);

    public Task<Result<EntityNotFoundError<T>, T>> FindAsync(Guid id);

    public Task UpdateAsync(T entity);
}