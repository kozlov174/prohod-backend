namespace Prohod.WebApi.VisitRequests.Models.Dto;

public record FormDto(
    PassportDto Passport,
    DateTimeOffset VisitTime,
    string VisitReason,
    Guid UserToVisitId,
    string EmailToSendReply);