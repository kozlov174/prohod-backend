namespace Prohod.Domain.Applications;

public interface IApplicationRepository
{
    public Task AddApplication(Application application);
}