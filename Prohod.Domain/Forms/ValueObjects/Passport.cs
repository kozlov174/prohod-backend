namespace Prohod.Domain.Forms;

public record Passport(
    FullName FullName,
    PassportSeries PassportSeries,
    PassportNumber PassportNumber,
    WhoIssued WhoIssued,
    IssueDate IssueDate);