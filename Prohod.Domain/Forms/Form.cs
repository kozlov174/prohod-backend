using Prohod.Domain.Users;

namespace Prohod.Domain.Forms;

public record Form(
    Guid Id,
    string FullName,
    string PassportSeries,
    string PassportNumber,
    DateTimeOffset VisitTime,
    User UserToVisit,
    string Email);