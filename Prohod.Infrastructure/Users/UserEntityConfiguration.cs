using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Users;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(user => user.Id)
            .HasConversion(id => id.Value, guid => new(guid));
        
        builder
            .Property(user => user.Name)
            .HasConversion(name => name.Value, str => new(str));
        
        builder
            .Property(user => user.Surname)
            .HasConversion(surname => surname.Value, str => new(str));

        builder
            .Property(user => user.Login)
            .HasConversion(login => login.Value, str => new(str));

        builder
            .HasIndex(user => user.Login)
            .IsUnique();
        
        builder
            .Property(user => user.PasswordHash)
            .HasConversion(hash => hash.Value, str => new(str));
        
        builder
            .Property(user => user.UserEmail)
            .HasConversion(email => email.Value, str => new(str));
    }
}