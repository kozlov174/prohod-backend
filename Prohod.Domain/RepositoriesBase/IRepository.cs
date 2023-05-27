using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kontur.Results;

namespace Prohod.Domain.RepositoriesBase;

public interface IRepository<T>
{
    public Task AddAsync(T entity);

    public Task<Result<EntityNotFound<T>, T>> Get(Expression<Func<T, bool>> specification);

    public Task<bool> Exists(Expression<Func<T, bool>> specification);
}