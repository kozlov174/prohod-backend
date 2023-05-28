using Prohod.Domain.Users;

namespace Prohod.Domain.VisitRequests.Forms;

public record FormAggregated(
    FormId Id,
    Passport Passport,
    VisitTime VisitTime,
    VisitReason VisitReason,
    User UserToVisit,
    EmailToSendReply EmailToSendReply)
{
    public FormAggregated(Form form, User userToVisit)
        : this(form.Id, form.Passport, form.VisitTime, form.VisitReason, userToVisit, form.EmailToSendReply)
    {
        if (form.UserToVisitId != userToVisit.Id)
        {
            throw new ArgumentException("Form user to visit id should match provided user id");
        }
    }
};