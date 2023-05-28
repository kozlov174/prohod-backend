using System.Linq.Expressions;
using Kontur.Results;
using Microsoft.EntityFrameworkCore;
using Prohod.Domain.GenericRepository;

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

    public async Task<Result<EntityNotFound<T>, T>> SingleAsync(Expression<Func<T, bool>> specification)
    {
        var entity = await dbContext.Set<T>().SingleOrDefaultAsync(specification);

        if (entity is null)
        {
            return new EntityNotFound<T>();
        }
        
        return entity;
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> specification)
        => await dbContext.Set<T>().AnyAsync(specification);

    public async Task<IReadOnlyCollection<T>> GetPage<TOrderProperty>(
        Expression<Func<T, TOrderProperty>> orderPropertySelector, int offset, int limit) =>
        await dbContext.Set<T>()
            .OrderBy(orderPropertySelector)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
}