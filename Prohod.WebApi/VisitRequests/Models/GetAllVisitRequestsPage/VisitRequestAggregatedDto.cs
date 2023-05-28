using Prohod.Domain.VisitRequests;
using Prohod.WebApi.Users.Models;

namespace Prohod.WebApi.VisitRequests.Models.Dto;

public record VisitRequestAggregatedDto(
    Guid Id,
    FormAggregatedDto Form,
    UserDto? WhoProcessed,
    VisitRequestStatus Status,
    string? RejectionReason);