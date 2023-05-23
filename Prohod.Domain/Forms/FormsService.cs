using Prohod.Domain.Applications;

namespace Prohod.Domain.Forms;

public class FormsService : IFormsService
{
    private readonly IVisitRequestsService visitRequestsService;
    private readonly IFormsRepository formsRepository;

    public FormsService(IVisitRequestsService visitRequestsService, IFormsRepository formsRepository)
    {
        this.visitRequestsService = visitRequestsService;
        this.formsRepository = formsRepository;
    }

    public async Task CreateForm(Form form)
    {
        await formsRepository.AddForm(form);

        await visitRequestsService.CreateVisitRequest(form);
    }
}