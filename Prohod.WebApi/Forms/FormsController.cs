using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prohod.Domain.Forms;
using Prohod.WebApi.Forms.Models;

namespace Prohod.WebApi.Forms;

[Route("/forms")]
public class FormsController : ControllerBase
{
    private readonly IFormsService formsService;
    private readonly IMapper mapper;

    public FormsController(IFormsService formsService, IMapper mapper)
    {
        this.formsService = formsService;
        this.mapper = mapper;
    }

    [HttpPost("/apply")]
    public async Task<ActionResult> ApplyForm(ApplyFormRequest request)
    {
        var form = mapper.Map<Form>(request.Form);

        await formsService.ApplyFormAsync(form);

        return Ok(); // TODO Egor Add CreatedAtAction when VisitRequests.Read added
    }
}