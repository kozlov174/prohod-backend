namespace Prohod.WebApi.VisitRequests.Models.Forms;

public record PassportDto(
    string FullName,
    string Series,
    string Number,
    string WhoIssued,
    DateTimeOffset IssueDate);