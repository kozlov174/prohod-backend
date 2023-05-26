using System;

namespace Prohod.Domain.Users;

public record User
{
    public required Guid Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Surname { get; init; }
    
    public required string Login { get; init; }
    
    public required string PasswordHash { get; init; }
    
    public required string Email { get; init; }
    
    public required Role Role { get; init; }
}