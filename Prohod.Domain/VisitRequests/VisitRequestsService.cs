using Kontur.Results;
using Prohod.Domain.GenericRepository;
using Prohod.Domain.Users;
using Prohod.Domain.Users.Errors;
using Prohod.Domain.VisitRequests.Forms;

namespace Prohod.Domain.VisitRequests;


public class VisitRequestsService : IVisitRequestsService
{
    private readonly IRepository<VisitRequest> visitRequestsRepository;
    private readonly IRepository<Form> formsRepository;
    private readonly IRepository<User> usersRepository;

    public VisitRequestsService(
        IRepository<VisitRequest> visitRequestsRepository,
        IRepository<Form> formsRepository,
        IRepository<User> usersRepository)
    {
        this.visitRequestsRepository = visitRequestsRepository;
        this.formsRepository = formsRepository;
        this.usersRepository = usersRepository;
    }

    public async Task<Result<IApplyFormError>> ApplyFormAsync(Form form)
    {
        var userExists = await usersRepository.ExistsAsync(user => user.Id == form.UserToVisitId);
        if (!userExists)
        {
            return new UserToVisitWasNotFound(form.UserToVisitId);
        }
        
        await formsRepository.AddAsync(form);
        await visitRequestsRepository.AddAsync(new VisitRequest { FormId = form.Id });
        return Result.Succeed();
    }
}