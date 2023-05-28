using Prohod.Domain.VisitRequests;
using Prohod.WebApi.Users.Models;
using Prohod.WebApi.VisitRequests.Models.Forms;

namespace Prohod.WebApi.VisitRequests.Models.GetAllVisitRequestsPage;

public record VisitRequestAggregatedDto(
    Guid Id, FormAggregatedDto Form, UserDto? WhoProcessed, VisitRequestStatus Status, string? RejectionReason);