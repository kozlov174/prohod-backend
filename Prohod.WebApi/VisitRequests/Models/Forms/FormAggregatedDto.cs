using Prohod.WebApi.Users.Models;

namespace Prohod.WebApi.VisitRequests.Models.Forms;

public record FormAggregatedDto(
    Guid Id,
    PassportDto Passport,
    DateTimeOffset VisitTime,
    string VisitReason,
    UserDto UserToVisit,
    string EmailToSendReply);