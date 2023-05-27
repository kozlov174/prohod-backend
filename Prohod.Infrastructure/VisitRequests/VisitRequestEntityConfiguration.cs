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
            .Property(request => request.Id)
            .HasColumnName(nameof(VisitRequest.Id))
            .HasConversion(id => id.Value, guid => new(guid));
        
        builder
            .Property(request => request.FormId)
            .HasConversion(id => id.Value, guid => new(guid))
            .HasColumnName(nameof(VisitRequest.FormId));

        builder
            .HasOne<Form>()
            .WithOne()
            .HasForeignKey<VisitRequest>(request => request.FormId);
        
        builder
            .Property(request => request.WhoProcessedId)
            .HasConversion(id => id!.Value, guid => new(guid))
            .HasColumnName(nameof(VisitRequest.WhoProcessedId));
        
        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(request => request.WhoProcessedId);
        
        builder
            .OwnsOne<RejectionReason>(request => request.RejectionReason)
            .Property(reason => reason.Value)
            .HasColumnName(nameof(VisitRequest.RejectionReason));
    }
}