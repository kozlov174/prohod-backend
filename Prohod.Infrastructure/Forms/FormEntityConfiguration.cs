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
            passport
                .Property(properties => properties.FullName)
                .HasConversion(name => name.Value, str => new(str));
            
            passport
                .Property(properties => properties.Series)
                .HasConversion(passportSeries => passportSeries.Value, str => new(str));
            
            passport
                .Property(properties => properties.Number)
                .HasConversion(passportNumber => passportNumber.Value, str => new(str));
            
            passport
                .Property(properties => properties.WhoIssued)
                .HasConversion(whoIssued => whoIssued.Value, str => new(str));
            
            passport
                .Property(properties => properties.IssueDate)
                .HasConversion(issueDate => issueDate.Value, date => new(date));
        });

        builder
            .Property(form => form.VisitTime)
            .HasConversion(time => time.Value, dateTime => new(dateTime));
        
        builder
            .Property(form => form.VisitReason)
            .HasConversion(reason => reason.Value, str => new(str));
        
        builder
            .Property(form => form.UserToVisitId)
            .HasConversion(id => id.Value, guid => new(guid));

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(form => form.UserToVisitId);

        builder
            .Property(form => form.EmailToSendReply)
            .HasConversion(time => time.Value, str => new(str));
        
    }
}