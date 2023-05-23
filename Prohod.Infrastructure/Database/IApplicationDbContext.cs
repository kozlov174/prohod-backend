using Microsoft.EntityFrameworkCore;
using Prohod.Domain.Applications;
using Prohod.Domain.Users;
using Prohod.Infrastructure.Users;

namespace Prohod.Infrastructure.Database;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; }
    
    public DbSet<Application> Applications { get; }

    public Task<int> SaveChangesAsync();
}