using myWorks.Application.Features.InterviewMAnagement.Query.GetInterviewDetailByApplicantId;
using myWorks.Domain.myWorkDb;

namespace myWorks.Application.Extension;

public static class InterviewDetailExtension
{
    public static GetInterviewDetailByApplicantionIdQueryDto MapToGetInterviewDetailByApplicantIdQueryDto(this InterviewDetail interviewDetail)
    {
        return new GetInterviewDetailByApplicantionIdQueryDto
        {
            InterviewId = interviewDetail.InterviewId,
            ApplicationId = interviewDetail.ApplicationId,
            InterviewDate = interviewDetail.InterviewDate,
            Interviewer = interviewDetail.Interviewer,
            Notes = interviewDetail.Notes,

        };
    }
}
