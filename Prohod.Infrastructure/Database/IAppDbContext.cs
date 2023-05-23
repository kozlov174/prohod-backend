using Microsoft.EntityFrameworkCore;
using Prohod.Domain.Applications;
using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Database;

public interface IAppDbContext
{
    public DbSet<User> Users { get; }
    
    public DbSet<VisitRequest> VisitRequests { get; }

    public Task<int> SaveChangesAsync();
}