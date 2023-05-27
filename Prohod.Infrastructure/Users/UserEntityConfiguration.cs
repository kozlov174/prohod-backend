using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prohod.Domain;
using Prohod.Domain.Users;

namespace Prohod.Infrastructure.Users;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(user => user.Id)
            .HasConversion(id => id.Value, guid => new(guid))
            .HasColumnName(nameof(User.Id));
        
        builder
            .OwnsOne<Name>(user => user.Name)
            .Property(name => name.Value)
            .HasColumnName(nameof(User.Name));
        
        builder
            .OwnsOne<Surname>(user => user.Surname)
            .Property(surname => surname.Value)
            .HasColumnName(nameof(User.Surname));
        
        builder
            .OwnsOne<Login>(user => user.Login)
            .Property(login => login.Value)
            .HasColumnName(nameof(User.Login));
        
        builder
            .OwnsOne<PasswordHash>(user => user.PasswordHash)
            .Property(passwordHash => passwordHash.Value)
            .HasColumnName(nameof(User.PasswordHash));
        
        builder
            .OwnsOne<Email>(user => user.Email)
            .Property(email => email.Value)
            .HasColumnName(nameof(User.Email));
    }
}