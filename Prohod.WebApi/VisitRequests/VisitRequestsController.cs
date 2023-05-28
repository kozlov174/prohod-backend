using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prohod.Domain.ErrorsBase;
using Prohod.Domain.Users;
using Prohod.Domain.VisitRequests;
using Prohod.Domain.VisitRequests.Forms;
using Prohod.WebApi.Users.Authorization;
using Prohod.WebApi.VisitRequests.Models.Dto;
using Prohod.WebApi.VisitRequests.Models.Requests;
using Prohod.WebApi.VisitRequests.Models.Responses;

namespace Prohod.WebApi.VisitRequests;

[Route("/api/v1/visit-requests")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class VisitRequestsController : ControllerBase
{
    private readonly IVisitRequestsService visitRequestsService;
    private readonly IVisitRequestsRepository visitRequestsRepository;
    private readonly IOperationErrorVisitor<ActionResult> errorVisitor;
    private readonly IMapper mapper;

    public VisitRequestsController(
        IVisitRequestsService visitRequestsService,
        IVisitRequestsRepository visitRequestsRepository,
        IOperationErrorVisitor<ActionResult> errorVisitor,
        IMapper mapper)
    {
        this.visitRequestsService = visitRequestsService;
        this.visitRequestsRepository = visitRequestsRepository;
        this.errorVisitor = errorVisitor;
        this.mapper = mapper;
    }

    [HttpPost("apply")]
    public async Task<ActionResult> ApplyForm(ApplyFormRequest request)
    {
        var form = mapper.Map<Form>(request.Form);

        var applyResult = await visitRequestsService.ApplyFormAsync(form);

        return applyResult.TryGetFault(out var fault)
            ? fault.Accept(errorVisitor)
            : CreatedAtAction(nameof(GetNotProcessedVisitRequestsPage), null);
    }
    
    [AuthorizedRoles(Role.Security)]
    [HttpGet("statuses/not-processed")]
    public async Task<ActionResult<GetNotProcessedVisitRequestsPageResponse>> GetNotProcessedVisitRequestsPage(
        [FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var visitRequests = await visitRequestsRepository.GetVisitRequestsPage(
            new[] { VisitRequestStatus.NotProcessed }, offset, limit);

        return new GetNotProcessedVisitRequestsPageResponse(
            mapper.Map<IEnumerable<NotProcessedVisitRequestAggregatedDto>>(visitRequests));
    }
    
    [AuthorizedRoles(Role.Security)]
    [HttpGet("statuses/user-processed")]
    public async Task<ActionResult<GetUserProcessedVisitRequestsPageResponse>> GetUserProcessedVisitRequestsPage(
        [FromQuery] Guid userId, [FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var visitRequests = await visitRequestsRepository.GetUserVisitRequestsPage(new(userId), offset, limit);

        return new GetUserProcessedVisitRequestsPageResponse(
            mapper.Map<IEnumerable<UserProcessedVisitRequestAggregatedDto>>(visitRequests));
    }

    [AuthorizedRoles(Role.Admin)]
    [HttpGet("statuses/all")]
    public async Task<ActionResult<GetAllVisitRequestsPageResponse>> GetAllVisitRequestsAggregationsPage(
        [FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var visitRequests = await visitRequestsRepository.GetVisitRequestsPage(
            new[] { VisitRequestStatus.NotProcessed, VisitRequestStatus.Accept, VisitRequestStatus.Reject },
            offset,
            limit);

        return new GetAllVisitRequestsPageResponse(
            mapper.Map<IEnumerable<VisitRequestAggregatedDto>>(visitRequests));
    }
}