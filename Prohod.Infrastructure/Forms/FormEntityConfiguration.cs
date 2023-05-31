using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prohod.Domain.Forms;

namespace Prohod.Infrastructure.Forms;

public class FormEntityConfiguration : IEntityTypeConfiguration<Form>
{
    private const string UserToVisitId = nameof(Form.UserToVisit) + nameof(Form.Id);
    
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.OwnsOne(form => form.Passport);
    }
}