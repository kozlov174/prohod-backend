namespace Prohod.WebApi.VisitRequests.Models.Dto;

public record PassportDto(
    string FullName,
    string Series,
    string Number,
    string WhoIssued,
    DateTimeOffset IssueDate);