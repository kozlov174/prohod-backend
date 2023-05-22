using Microsoft.EntityFrameworkCore;
using Prohod.Infrastructure.Users;

namespace Prohod.Infrastructure.Database;

public sealed class PostgresDbContext : DbContext, IApplicationDbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<UserDbRepresentation> Users { get; set; } = default!;
    
    public async Task<int> SaveChangesAsync()
        => await base.SaveChangesAsync().ConfigureAwait(false);
}