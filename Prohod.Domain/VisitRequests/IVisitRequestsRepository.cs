using Prohod.Domain.GenericRepository;

namespace Prohod.Domain.VisitRequests;

public interface IVisitRequestsRepository : IRepository<VisitRequest>
{
    public Task<IReadOnlyList<VisitRequest>> GetNotProcessedVisitRequestsPageAsync(int offset, int limit);
    
    public Task<IReadOnlyList<VisitRequest>> GetVisitRequestsPageAsync(int offset, int limit);

    public Task<IReadOnlyList<VisitRequest>> GetUserProcessedVisitRequestsPageAsync(
        Guid userId, int offset, int limit);
}