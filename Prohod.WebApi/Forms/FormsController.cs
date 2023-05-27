using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prohod.Domain.ErrorsBase;
using Prohod.Domain.Forms;
using Prohod.WebApi.Forms.Models;

namespace Prohod.WebApi.Forms;

[Route("/api/v1/forms")]
public class FormsController : ControllerBase
{
    private readonly IFormsService formsService;
    private readonly IMapper mapper;
    private readonly IOperationErrorVisitor<ActionResult> errorVisitor;

    public FormsController(
        IFormsService formsService,
        IOperationErrorVisitor<ActionResult> errorVisitor,
        IMapper mapper)
    {
        this.formsService = formsService;
        this.errorVisitor = errorVisitor;
        this.mapper = mapper;
    }

    [HttpPost("apply")]
    public async Task<ActionResult> ApplyForm(ApplyFormRequest request)
    {
        var form = mapper.Map<Form>(request.Form);

        var applyResult = await formsService.ApplyFormAsync(form);

        return applyResult.TryGetFault(out var fault)
            ? fault.Accept(errorVisitor)
            : Ok(); // TODO Egor replace with CreatedAtAction when VisitRequestsController.Read method added
    }
}