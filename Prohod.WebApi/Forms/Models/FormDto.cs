using System;

namespace Prohod.WebApi.Forms.Models;

public record FormDto(
    string FullName,
    string PassportSeries,
    string PassportNumber,
    string WhoIssued,
    DateTimeOffset IssueDate,
    DateTimeOffset VisitTime,
    Guid UserToVisitId,
    string EmailToSendReply);