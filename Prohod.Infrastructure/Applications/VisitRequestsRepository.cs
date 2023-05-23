using Prohod.Domain.Applications;
using Prohod.Infrastructure.Database;

namespace Prohod.Infrastructure.Applications;

public class VisitRequestsRepository : IVisitRequestsRepository
{
    private readonly IAppDbContext dbContext;

    public VisitRequestsRepository(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddVisitRequest(VisitRequest visitRequest)
    {
        dbContext.VisitRequests.Add(visitRequest);

        await dbContext.SaveChangesAsync();
    }
}