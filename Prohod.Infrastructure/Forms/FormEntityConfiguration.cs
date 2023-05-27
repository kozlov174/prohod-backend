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
            .Property(form => form.Id)
            .HasConversion(id => id.Value, guid => new(guid))
            .HasColumnName(nameof(Form.Id));

        builder.OwnsOne(form => form.Passport, passport =>
        {
            passport.Property(properties => properties.FullName)
                .HasConversion(name => name.Value, str => new(str))
                .HasColumnName(nameof(Passport.FullName));
            
            passport.Property(properties => properties.PassportSeries)
                .HasConversion(passportSeries => passportSeries.Value, str => new(str))
                .HasColumnName(nameof(Passport.PassportSeries));
            
            passport.Property(properties => properties.PassportNumber)
                .HasConversion(passportNumber => passportNumber.Value, str => new(str))
                .HasColumnName(nameof(Passport.PassportNumber));
            
            passport.Property(properties => properties.WhoIssued)
                .HasConversion(whoIssued => whoIssued.Value, str => new(str))
                .HasColumnName(nameof(Passport.WhoIssued));
            
            passport.Property(properties => properties.IssueDate)
                .HasConversion(issueDate => issueDate.Value, date => new(date))
                .HasColumnName(nameof(Passport.IssueDate));
        });

        builder.OwnsOne(form => form.VisitTime).Property(time => time.Value).HasColumnName(nameof(Form.VisitTime));
        
        builder
            .Property(form => form.UserToVisitId)
            .HasConversion(id => id.Value, guid => new(guid))
            .HasColumnName(nameof(Form.UserToVisitId));

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(form => form.UserToVisitId);

        builder.OwnsOne(form => form.EmailToSendReply).Property(email => email.Value).HasColumnName(nameof(Form.EmailToSendReply));
    }
}