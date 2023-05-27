namespace Prohod.Domain.Forms;

public record Passport(
    FullName FullName,
    PassportSeries Series,
    PassportNumber Number,
    WhoIssued WhoIssued,
    IssueDate IssueDate);