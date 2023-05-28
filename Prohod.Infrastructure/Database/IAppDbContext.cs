using Microsoft.EntityFrameworkCore;

namespace Prohod.Infrastructure.Database;

public interface IAppDbContext
{
    DbSet<T> Set<T>()
        where T : class;

    public Task<int> SaveChangesAsync();
}