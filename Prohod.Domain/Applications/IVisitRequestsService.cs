using Prohod.Domain.Forms;

namespace Prohod.Domain.Applications;

public interface IVisitRequestsService
{
    public Task CreateVisitRequest(Form form);
}