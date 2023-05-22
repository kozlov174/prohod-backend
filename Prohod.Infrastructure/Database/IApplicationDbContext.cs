using Microsoft.EntityFrameworkCore;
using Prohod.Infrastructure.Users;

namespace Prohod.Infrastructure.Database;

public interface IApplicationDbContext
{
    public DbSet<UserDbRepresentation> Users { get; }

    public Task<int> SaveChangesAsync();
}