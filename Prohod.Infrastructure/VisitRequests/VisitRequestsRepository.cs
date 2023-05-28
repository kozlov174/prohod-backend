using System.Linq.Expressions;
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
        Expression<Func<VisitRequest, bool>> predicate, int offset, int limit)
    {
        var forms = dbContext.Set<Form>();
        var requests = dbContext.Set<VisitRequest>();
        var users = dbContext.Set<User>();
        var query =
            from request in requests.Where(predicate)
            join form in forms on request.FormId equals form.Id
            join userToVisit in users on form.UserToVisitId equals userToVisit.Id
            join whoProcessed in users on request.WhoProcessedId equals whoProcessed.Id into grouping
            from whoProcessed in grouping.DefaultIfEmpty()
            orderby form.VisitTime
            select new VisitRequestAggregated(request, new(form, userToVisit), whoProcessed);
        return await query.ToListAsync();
    }
}