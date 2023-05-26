using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prohod.Domain.Forms;
using Prohod.Domain.Users;
using Prohod.Domain.VisitRequests;
using Prohod.Infrastructure.Forms;
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
        modelBuilder.ApplyConfiguration(new FormEntityConfiguration());
        modelBuilder.ApplyConfiguration(new VisitRequestEntityConfiguration());
    }
}