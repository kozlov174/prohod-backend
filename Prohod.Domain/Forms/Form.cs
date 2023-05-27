using System;
using Prohod.Domain.Users;

namespace Prohod.Domain.Forms;

public class Form
{
    public FormId Id { get; init; } = new(Guid.NewGuid());
    
    public required Passport Passport { get; init; }
    
    public required VisitTime VisitTime { get; init; }
    
    public required UserId UserToVisitId { get; init; }
    
    public required EmailToSendReply EmailToSendReply { get; init; }
}