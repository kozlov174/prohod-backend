using Microsoft.EntityFrameworkCore;
using Prohod.Domain.Users;
using Prohod.Domain.VisitRequests;
using Prohod.Domain.VisitRequests.Forms;
using Prohod.Infrastructure.Database;

namespace Prohod.Infrastructure.VisitRequests;

public class VisitRequestsRepository : IVisitRequestsRepository
{
    private readonly IAppDbContext dbContext;

    public VisitRequestsRepository(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<IReadOnlyCollection<VisitRequestAggregated>> GetVisitRequestsPage(
        VisitRequestStatus[] possibleStatus, int offset, int limit)
    {
        var forms = dbContext.Set<Form>();
        var requests = dbContext.Set<VisitRequest>();
        var users = dbContext.Set<User>();
        var query =
            from request in requests
            where possibleStatus.Contains(request.Status)
            join form in forms on request.FormId equals form.Id
            join user in users on form.UserToVisitId equals user.Id
            orderby form.VisitTime
            select new VisitRequestAggregated(request.Id, new(form, user), null, request.Status, null);
        
        return await query.ToListAsync();
    }

    public async Task<IReadOnlyCollection<VisitRequestAggregated>> GetUserVisitRequestsPage(UserId userId, int offset, int limit)
    {
        var forms = dbContext.Set<Form>();
        var requests = dbContext.Set<VisitRequest>();
        var users = dbContext.Set<User>();
        var query =
            from request in requests
            where request.WhoProcessedId == userId
            join form in forms on request.FormId equals form.Id
            join user in users on form.UserToVisitId equals user.Id
            orderby form.VisitTime
            select new VisitRequestAggregated(request, new(form, user));
        
        return await query.ToListAsync();
    }
}