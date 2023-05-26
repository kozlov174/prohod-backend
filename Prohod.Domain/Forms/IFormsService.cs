using System.Threading.Tasks;

namespace Prohod.Domain.Forms;

public interface IFormsService
{
    public Task ApplyFormAsync(Form form);
}