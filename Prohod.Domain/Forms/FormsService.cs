using Prohod.Domain.Applications;

namespace Prohod.Domain.Forms;

public class FormsService : IFormsService
{
    private readonly IApplicationsService applicationsService;
    private readonly IFormsRepository formsRepository;

    public FormsService(IApplicationsService applicationsService, IFormsRepository formsRepository)
    {
        this.applicationsService = applicationsService;
        this.formsRepository = formsRepository;
    }

    public async Task CreateForm(Form form)
    {
        await formsRepository.AddForm(form);

        await applicationsService.CreateApplication(form);
    }
}