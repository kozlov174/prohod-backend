using Microsoft.EntityFrameworkCore;
using Prohod.Domain.Applications;
using Prohod.Domain.Users;
using Prohod.Infrastructure.Applications;
using Prohod.Infrastructure.Users;

namespace Prohod.Infrastructure.Database;

public sealed class PostgresDbContext : DbContext, IApplicationDbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; } = default!;

    public DbSet<Application> Applications { get; set; } = default!;

    public async Task<int> SaveChangesAsync()
        => await base.SaveChangesAsync().ConfigureAwait(false);
}