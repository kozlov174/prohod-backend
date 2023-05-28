using System.Linq.Expressions;

namespace Prohod.Domain.VisitRequests;

public interface IVisitRequestsRepository
{
    public Task<IReadOnlyCollection<VisitRequestAggregated>> GetVisitRequestsPage(
        Expression<Func<VisitRequest, bool>> predicate, int offset, int limit);
}