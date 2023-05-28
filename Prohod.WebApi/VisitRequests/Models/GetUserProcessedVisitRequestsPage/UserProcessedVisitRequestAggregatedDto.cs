using Prohod.WebApi.Users.Models;

namespace Prohod.WebApi.VisitRequests.Models.Dto;

public record UserProcessedVisitRequestAggregatedDto(
    Guid Id, FormAggregatedDto Form, UserDto User, string? RejectionReason);
