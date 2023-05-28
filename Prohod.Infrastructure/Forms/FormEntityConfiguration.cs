using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prohod.Domain.Users;
using Prohod.Domain.VisitRequests.Forms;

namespace Prohod.Infrastructure.Forms;

public class FormEntityConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder
            .Property(form => form.Id)
            .HasConversion(id => id.Value, guid => new(guid));

        builder.OwnsOne(form => form.Passport, passport =>
        {
            passport.Property(properties => properties.FullName)
                .HasConversion(name => name.Value, str => new(str));
            
            passport.Property(properties => properties.Series)
                .HasConversion(passportSeries => passportSeries.Value, str => new(str));
            
            passport.Property(properties => properties.Number)
                .HasConversion(passportNumber => passportNumber.Value, str => new(str));
            
            passport.Property(properties => properties.WhoIssued)
                .HasConversion(whoIssued => whoIssued.Value, str => new(str));
            
            passport.Property(properties => properties.IssueDate)
                .HasConversion(issueDate => issueDate.Value, date => new(date));
        });

        builder
            .OwnsOne(form => form.VisitTime)
            .Property(time => time.Value)
            .HasColumnName(nameof(Form.VisitTime));
        
        builder
            .Property(form => form.UserToVisitId)
            .HasConversion(id => id.Value, guid => new(guid));

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(form => form.UserToVisitId);

        builder
            .OwnsOne(form => form.EmailToSendReply)
            .Property(email => email.Value)
            .HasColumnName(nameof(Form.EmailToSendReply));

        builder
            .OwnsOne(form => form.VisitReason)
            .Property(reason => reason.Value)
            .HasColumnName(nameof(Form.VisitReason));
    }
}