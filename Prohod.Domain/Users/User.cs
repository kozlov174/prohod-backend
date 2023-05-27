using System;

namespace Prohod.Domain.Users;

public record User
{
    public UserId Id { get; init; } = new(Guid.NewGuid());
    
    public required Name Name { get; init; }
    
    public required Surname Surname { get; init; }
    
    public required Login Login { get; init; }
    
    public required PasswordHash PasswordHash { get; init; }
    
    public required Email Email { get; init; }
    
    public required Role Role { get; init; }
}