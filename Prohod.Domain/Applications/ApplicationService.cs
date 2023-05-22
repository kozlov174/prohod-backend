using Prohod.Domain.Forms;

namespace Prohod.Domain.Applications;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository applicationRepository;

    public ApplicationService(IApplicationRepository applicationRepository)
    {
        this.applicationRepository = applicationRepository;
    }

    public async Task CreateApplication(Form form)
    {
        var application = new Application(Guid.NewGuid(), form, null, ApplicationStatus.NotProcessed, null);
        
        await applicationRepository.AddApplication(application);
    }
}