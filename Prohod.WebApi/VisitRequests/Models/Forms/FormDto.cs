namespace Prohod.WebApi.VisitRequests.Models.Forms;

public record FormDto(
    PassportDto Passport,
    DateTimeOffset VisitTime,
    string VisitReason,
    Guid UserToVisitId,
    string EmailToSendReply);