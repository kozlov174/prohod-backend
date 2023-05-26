using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prohod.Domain.Forms;
using Prohod.Domain.Users;
using Prohod.Domain.VisitRequests;

namespace Prohod.Infrastructure.VisitRequests;

public class VisitRequestEntityConfiguration : IEntityTypeConfiguration<VisitRequest>
{
    public void Configure(EntityTypeBuilder<VisitRequest> builder)
    {
        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(request => request.WhoProcessedId);

        builder
            .HasOne<Form>()
            .WithOne()
            .HasForeignKey<VisitRequest>(request => request.FormId);
    }
}