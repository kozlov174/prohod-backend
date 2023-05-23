using Prohod.Domain.Forms;

namespace Prohod.Domain.Applications;

public class VisitRequestsService : IVisitRequestsService
{
    private readonly IVisitRequestsRepository visitRequestsRepository;

    public VisitRequestsService(IVisitRequestsRepository visitRequestsRepository)
    {
        this.visitRequestsRepository = visitRequestsRepository;
    }

    public async Task CreateVisitRequest(Form form)
    {
        var application = new VisitRequest(Guid.NewGuid(), form, null, VisitRequestStatus.NotProcessed, null);
        
        await visitRequestsRepository.AddVisitRequest(application);
    }
}