using myWorks.Domain.myWorkDb;
namespace myWorks.Application.Features.ApplicantManagement.Command.UpdateApplicant;

public static class UpdateApplicantCommandExtension
{
    public static ApplicantInformation MapToApplicationInformation(this UpdateApplicantCommand cmd)
    {
        return new ApplicantInformation
        {
            ApplicantId = cmd.ApplicantId,
            FirstName = cmd.FirstName,
            LastName = cmd.LastName,
            Email = cmd.Email,
            PhoneNumber = cmd.PhoneNumber,
            DateOfBirth = cmd.DateOfBirth,
            Address = cmd.Address,
            City = cmd.City,
            State = cmd.State,
            Country = cmd.Country,
            CreatedAt = cmd.CreatedAt,
            UpdatedAt = cmd.UpdatedAt
        };
    }
}
