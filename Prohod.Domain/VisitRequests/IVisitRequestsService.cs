using Kontur.Results;
using Prohod.Domain.Users.Errors;
using Prohod.Domain.VisitRequests.Forms;

namespace Prohod.Domain.VisitRequests;

public interface IVisitRequestsService
{
    public Task<Result<IApplyFormError>> ApplyFormAsync(Form form);
}