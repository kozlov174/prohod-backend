using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kontur.Results;
using Microsoft.EntityFrameworkCore;
using Prohod.Domain.RepositoriesBase;

namespace Prohod.Infrastructure.Database;

public class Repository<T> : IRepository<T>
    where T: class
{
    private readonly IAppDbContext dbContext;

    public Repository(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);

        await dbContext.SaveChangesAsync();
    }

    public async Task<Result<EntityNotFound<T>, T>> Get(Expression<Func<T, bool>> specification)
    {
        var entity = await dbContext.Set<T>().SingleOrDefaultAsync(specification);

        if (entity is null)
        {
            return new EntityNotFound<T>();
        }
        
        return entity;
    }

    public async Task<bool> Exists(Expression<Func<T, bool>> specification)
        => await dbContext.Set<T>().AnyAsync(specification);
}