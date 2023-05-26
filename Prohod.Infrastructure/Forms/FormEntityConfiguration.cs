using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prohod.Domain.Forms;
using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Forms;

public class FormEntityConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(form => form.UserToVisitId);
    }
}