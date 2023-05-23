namespace Prohod.Domain.Applications;

public interface IVisitRequestsRepository
{
    public Task AddVisitRequest(VisitRequest visitRequest);
}