using myWorks.Domain.myWorkDb;

namespace myWorks.Application.Features.Job_Application.Command.UpdateJobApplication;

public static class UpdateJobApplicationCommandExtension
{
    public static JobApplication MapToJobApplication(this UpdateJobApplicationCommand command)
    {
        return new JobApplication
        {
            ApplicationId = command.ApplicationId,
            ApplicantId = command.ApplicantId,
            JobTitle = command.JobTitle,
            ApplicationDate = command.ApplicationDate,
            Status = command.Status,
            Resume = command.Resume,
            Applicant = command.Applicant,
            InterviewDetails = command.InterviewDetails
        };
    }
}
