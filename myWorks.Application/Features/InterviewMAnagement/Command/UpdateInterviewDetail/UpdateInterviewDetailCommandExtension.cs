using myWorks.Domain.myWorkDb;

namespace myWorks.Application.Features.InterviewMAnagement.Command.UpdateInterviewDetail
{
    public static class UpdateInterviewDetailCommandExtension
    {
        public static InterviewDetail MapToInterviewDetail(this UpdateInterviewDetailCommand command)
        {
            return new InterviewDetail
            {
                InterviewId = command.InterviewId,
                ApplicationId = command.ApplicationId,
                InterviewDate = command.InterviewDate,
                Interviewer = command.Interviewer,
                Notes = command.Notes,
            };
        }
    }
}
