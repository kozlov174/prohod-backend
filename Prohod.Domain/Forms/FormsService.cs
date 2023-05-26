using System.Threading.Tasks;
using Prohod.Domain.RepositoriesBase;
using Prohod.Domain.VisitRequests;

namespace Prohod.Domain.Forms;

public class FormsService : IFormsService
{
    private readonly IRepository<VisitRequest> visitRequestsRepository;
    private readonly IRepository<Form> formsRepository;

    public FormsService(IRepository<VisitRequest> visitRequestsRepository, IRepository<Form> formsRepository)
    {
        this.visitRequestsRepository = visitRequestsRepository;
        this.formsRepository = formsRepository;
    }

    public async Task ApplyFormAsync(Form form)
    {
        await formsRepository.AddAsync(form);

        await visitRequestsRepository.AddAsync(new VisitRequest { FormId = form.Id });
    }
}