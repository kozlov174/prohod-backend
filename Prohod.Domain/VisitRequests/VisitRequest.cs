using System;
using Prohod.Domain.Forms;
using Prohod.Domain.Users;

namespace Prohod.Domain.VisitRequests;

public record VisitRequest
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public required Guid FormId { get; init; }

    public Guid? WhoProcessedId { get; init; } = null;

    public VisitRequestStatus Status { get; init; } = VisitRequestStatus.NotProcessed;

    public string? RejectionReason { get; init; } = null;
}