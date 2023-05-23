namespace Prohod.Domain.Applications;

public interface IApplicationsRepository
{
    public Task AddApplication(Application application);
}