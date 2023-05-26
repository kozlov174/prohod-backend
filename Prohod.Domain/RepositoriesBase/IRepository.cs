using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kontur.Results;

namespace Prohod.Domain.RepositoriesBase;

public interface IRepository<T>
{
    public Task AddAsync(T entity);

    public Task<Result<EntityNotFound<T>, T>> GetBySpecification(Expression<Func<T, bool>> specification);
}