using Prohod.Domain.Users;

namespace Prohod.Domain.VisitRequests;

public interface IVisitRequestsRepository
{
    public Task<IReadOnlyCollection<VisitRequestAggregated>> GetVisitRequestsPage(
        VisitRequestStatus[] possibleStatus, int offset, int limit);
    
    public Task<IReadOnlyCollection<VisitRequestAggregated>> GetUserVisitRequestsPage(
        UserId userId, int offset, int limit);
}