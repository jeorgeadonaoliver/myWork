
using myWorks.Application.Features.ApplicantManagement.Query.GetApplicant;
using myWorks.Application.Features.ApplicantManagement.Query.GetApplicantById;
using myWorks.Domain.myWorkDb;

namespace myWorks.Application.Extension
{
    public static class ApplicantInformationExtension 
    {
        public static GetApplicantQueryDto MapToGetApplicantQueryDto(this ApplicantInformation applicant) 
        {
            return new GetApplicantQueryDto
            {
                ApplicantId = applicant.ApplicantId,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                PhoneNumber = applicant.PhoneNumber,
                Address = applicant.Address,
                City = applicant.City,
                State = applicant.State,
                Country = applicant.Country,
                CreatedAt = applicant.CreatedAt,
                UpdatedAt = applicant.UpdatedAt
            };
        }

        public static GetApplicantByIdQueryDto MapToGetApplicantByIdQueryDto(this ApplicantInformation applicant) 
        {
            return new GetApplicantByIdQueryDto
            {
                ApplicantId = applicant.ApplicantId,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                PhoneNumber = applicant.PhoneNumber,
                Address = applicant.Address,
                City = applicant.City,
                State = applicant.State,
                Country = applicant.Country,
                CreatedAt = applicant.CreatedAt,
                UpdatedAt = applicant.UpdatedAt
            };
        }
    }
}
