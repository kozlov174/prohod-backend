using System;
using Prohod.Domain.Forms;
using Prohod.Domain.Users;

namespace Prohod.Domain.VisitRequests;

public record VisitRequest
{
    public VisitRequestId Id { get; init; } = new(Guid.NewGuid());
    
    public required FormId FormId { get; init; }

    public UserId? WhoProcessedId { get; init; } = null;

    public VisitRequestStatus Status { get; init; } = VisitRequestStatus.NotProcessed;

    public RejectionReason? RejectionReason { get; init; } = null;
}