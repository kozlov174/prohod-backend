using System;

namespace Prohod.Domain.Forms;

public record Form
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public required string FullName { get; init; }
    
    public required string PassportSeries { get; init; }
    
    public required string PassportNumber { get; init; }
    
    public required string WhoIssued { get; init; }
    
    public required DateTimeOffset IssueDate { get; init; }
    
    public required DateTimeOffset VisitTime { get; init; }
    
    public required Guid UserToVisitId { get; init; }
    
    public required string Email { get; init; }
}