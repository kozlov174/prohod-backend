using Prohod.WebApi.VisitRequests.Models.Forms;

namespace Prohod.WebApi.VisitRequests.Models.GetNotProcessedVisitRequestsPage;

public record NotProcessedVisitRequestAggregatedDto(
    Guid Id,
    FormAggregatedDto Form);