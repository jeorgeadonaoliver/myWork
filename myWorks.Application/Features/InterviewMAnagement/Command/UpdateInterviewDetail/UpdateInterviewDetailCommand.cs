using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.InterviewMAnagement.Command.UpdateInterviewDetail;

public class UpdateInterviewDetailCommand : IRequest<Result<Guid>>
{
    public Guid InterviewId { get; set; }

    public Guid ApplicationId { get; set; }

    public DateTime InterviewDate { get; set; }

    public string Interviewer { get; set; } = null!;

    public string? Notes { get; set; }
}
