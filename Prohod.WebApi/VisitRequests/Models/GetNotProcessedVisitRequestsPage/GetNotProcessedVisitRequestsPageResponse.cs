namespace Prohod.WebApi.VisitRequests.Models.GetNotProcessedVisitRequestsPage;

public record GetNotProcessedVisitRequestsPageResponse(
    IEnumerable<NotProcessedVisitRequestAggregatedDto> VisitRequest);