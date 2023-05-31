using Kontur.Results;
using Prohod.Domain.ErrorsBase;
using Prohod.Domain.Forms;
using Prohod.Domain.GenericRepository;
using Prohod.Domain.Users;

namespace Prohod.Domain.VisitRequests;

public interface IVisitRequestsService
{
    public Task<Result<EntityNotFoundError<User>>> ApplyFormAsync(ApplyFormDto form);

    public Task<Result<IOperationError>> AcceptRequestAsync(Guid visitRequestId, Guid whoAcceptedId);
    
    public Task<Result<IOperationError>> RejectRequestAsync(
        Guid visitRequestId, Guid whoProcessedId, string rejectionReason);

    public Task<IReadOnlyList<VisitRequest>> GetNotProcessedVisitRequestsPage(int offset, int limit);
    
    public Task<IReadOnlyList<VisitRequest>> GetVisitRequestsPage(int offset, int limit);
    
    public Task<Result<EntityNotFoundError<User>, IReadOnlyList<VisitRequest>>> GetUserProcessedVisitRequestsPage(
        Guid userId, int offset, int limit);
}