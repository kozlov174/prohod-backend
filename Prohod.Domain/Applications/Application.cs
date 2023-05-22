using Prohod.Domain.Forms;
using Prohod.Domain.Users;

namespace Prohod.Domain.Applications;

public record Application(Guid Id, Form Form, User? WhoProcessed, ApplicationStatus Status, string? RejectionReason);