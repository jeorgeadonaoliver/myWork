using myWorks.Domain.myWorkDb;

namespace myWorks.Application.Features.InterviewMAnagement.Query.GetInterviewDetailByApplicantionId;

public class GetInterviewDetailByApplicantionIdQueryDto
{
    public Guid InterviewId { get; set; }

    public Guid ApplicationId { get; set; }

    public DateTime InterviewDate { get; set; }

    public string Interviewer { get; set; } = null!;

    public string? Notes { get; set; }

}
