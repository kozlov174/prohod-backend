using Prohod.Domain.Forms;

namespace Prohod.Domain.Applications;

public interface IApplicationsService
{
    public Task CreateApplication(Form form);
}