using myWorks.Domain.myWorkDb;

namespace myWorks.Application.Features.Job_Application.Command.CreateJobApplication
{
    public static class CreateJobApplicationCommandExtension
    {
        public static JobApplication MapToJobApplication(this CreateJobApplicationCommand command)
        {
            return new JobApplication
            {
                ApplicationId = command.ApplicationId,
                ApplicantId = command.ApplicantId,
                JobTitle = command.JobTitle,
                ApplicationDate = command.ApplicationDate,
                Status = command.Status,
                Resume = command.Resume
            };
        }
    }
}
