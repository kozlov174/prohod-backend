using Prohod.Domain.Applications;

namespace Prohod.Domain.Forms;

public class FormsService : IFormsService
{
    private readonly IApplicationService applicationService;
    private readonly IFormsRepository formsRepository;

    public FormsService(IApplicationService applicationService, IFormsRepository formsRepository)
    {
        this.applicationService = applicationService;
        this.formsRepository = formsRepository;
    }

    public async Task CreateForm(Form form)
    {
        await formsRepository.AddForm(form);

        await applicationService.CreateApplication(form);
    }
}