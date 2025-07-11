using myWorks.Domain.myWorkDb;

namespace myWorks.Application.Features.InterviewMAnagement.Command.CreateInterviewDetail
{
    public static class CreateInterviewDetailCommandExtension
    {
        public static InterviewDetail MapToInterviewDetail(this CreateInterviewDetailCommand command)
        {
            return new InterviewDetail
            {
                InterviewId = command.InterviewId,
                ApplicationId = command.ApplicationId,
                InterviewDate = command.InterviewDate,
                Interviewer = command.Interviewer,
                Notes = command.Notes
            };
        }
    }
}
