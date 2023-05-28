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
    public VisitRequestAggregated(VisitRequest visitRequest, FormAggregated form, User? whoProcessed) 
        : this(visitRequest.Id, form, whoProcessed, visitRequest.Status, visitRequest.RejectionReason)
    {
    }
};