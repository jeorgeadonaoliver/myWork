
using myWorks.Application.Features.Job_Application.Query.GetJobApplication;
using myWorks.Application.Features.Job_Application.Query.GetJobApplicationByApplicant;
using myWorks.Domain.myWorkDb;

namespace myWorks.Application.Extension;

public static class JobApplicationExtension
{
    public static GetJobApplicationQueryDto MapToGetJobApplicationQueryDto(this JobApplication jobApplication)
    {
        return new GetJobApplicationQueryDto
        {
            ApplicationId = jobApplication.ApplicationId,
            ApplicantId = jobApplication.ApplicantId,
            JobTitle = jobApplication.JobTitle,
            ApplicationDate = jobApplication.ApplicationDate,
            Status = jobApplication.Status,
            Resume = jobApplication.Resume
        };
    }

    public static GetJobApplicationByApplicantIdQueryDto MapToGetJobApplicationByApplicantIdQueryDto(this JobApplication jobApplication) 
    {
        return new GetJobApplicationByApplicantIdQueryDto 
        {
            ApplicationId = jobApplication.ApplicationId,
            ApplicantId = jobApplication.ApplicantId,
            JobTitle = jobApplication.JobTitle,
            ApplicationDate = jobApplication.ApplicationDate,
            Status = jobApplication.Status,
            Resume = jobApplication.Resume
        };
    }
}
