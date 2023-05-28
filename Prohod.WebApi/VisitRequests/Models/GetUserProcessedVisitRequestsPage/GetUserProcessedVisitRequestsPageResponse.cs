using Prohod.WebApi.VisitRequests.Models.Dto;

namespace Prohod.WebApi.VisitRequests.Models.Responses;

public record GetUserProcessedVisitRequestsPageResponse(IEnumerable<UserProcessedVisitRequestAggregatedDto> VisitRequests);