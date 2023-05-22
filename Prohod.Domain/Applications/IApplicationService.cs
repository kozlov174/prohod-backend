using Prohod.Domain.Forms;

namespace Prohod.Domain.Applications;

public interface IApplicationService
{
    public Task CreateApplication(Form form);
}