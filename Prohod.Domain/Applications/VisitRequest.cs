using Prohod.Domain.Forms;
using Prohod.Domain.Users;

namespace Prohod.Domain.Applications;

public record VisitRequest(Guid Id, Form Form, User? WhoProcessed, VisitRequestStatus Status, string? RejectionReason);