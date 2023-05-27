using System.Threading.Tasks;
using Kontur.Results;
using Prohod.Domain.ErrorsBase;
using Prohod.Domain.Users.Errors;

namespace Prohod.Domain.Forms;

public interface IFormsService
{
    public Task<Result<IApplyFormError>> ApplyFormAsync(Form form);
}