using Prohod.Domain.Users;
using Prohod.Domain.VisitRequests.Forms;

namespace Prohod.Domain.VisitRequests;

public record VisitRequestAggregated(
    VisitRequestId Id,
    FormAggregated Form,
    User? WhoProcessed,
    VisitRequestStatus Status,
    RejectionReason? RejectionReason)
{
    public VisitRequestAggregated(VisitRequest visitRequest, FormAggregated form) :
        this(visitRequest.Id, form, null, visitRequest.Status, null)
    {
        if (visitRequest.FormId != form.Id)
        {
            throw new ArgumentException("Visit request form id should match provided form id");
        }
    }
}