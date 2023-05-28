using Microsoft.EntityFrameworkCore;
using Prohod.Domain.Users;
using Prohod.Domain.VisitRequests;
using Prohod.Domain.VisitRequests.Forms;
using Prohod.Infrastructure.Forms;
using Prohod.Infrastructure.Users;
using Prohod.Infrastructure.VisitRequests;

namespace Prohod.Infrastructure.Database;

public sealed class PostgresDbContext : DbContext, IAppDbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; } = default!;
    
    public DbSet<Form> Forms { get; set; } = default!;

    public DbSet<VisitRequest> VisitRequests { get; set; } = default!;

    public async Task<int> SaveChangesAsync()
        => await base.SaveChangesAsync().ConfigureAwait(false);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FormEntityConfiguration());
        modelBuilder.ApplyConfiguration(new VisitRequestEntityConfiguration());
    }
}