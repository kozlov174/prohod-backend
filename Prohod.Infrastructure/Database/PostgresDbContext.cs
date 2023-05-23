using Microsoft.EntityFrameworkCore;
using Prohod.Domain.Applications;
using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Database;

public sealed class PostgresDbContext : DbContext, IAppDbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; } = default!;

    public DbSet<VisitRequest> VisitRequests { get; set; } = default!;

    public async Task<int> SaveChangesAsync()
        => await base.SaveChangesAsync().ConfigureAwait(false);
}