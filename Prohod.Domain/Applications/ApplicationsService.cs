using Prohod.Domain.Forms;

namespace Prohod.Domain.Applications;

public class ApplicationsService : IApplicationsService
{
    private readonly IApplicationsRepository applicationsRepository;

    public ApplicationsService(IApplicationsRepository applicationsRepository)
    {
        this.applicationsRepository = applicationsRepository;
    }

    public async Task CreateApplication(Form form)
    {
        var application = new Application(Guid.NewGuid(), form, null, ApplicationStatus.NotProcessed, null);
        
        await applicationsRepository.AddApplication(application);
    }
}