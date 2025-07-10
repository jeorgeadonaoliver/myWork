using myWorks.Domain.myWorkDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWorks.Application.Features.ApplicantManagement.Command.CreateApplicant
{
    public static class CreateApplicantInformationCommandExtension
    {
        public static ApplicantInformation MapToApplicantInformation(this CreateApplicantInformationCommand cmd) 
        {
            return new ApplicantInformation { 
            
                ApplicantId = cmd.ApplicantId,
                Address = cmd.Address,
                CreatedAt = cmd.CreatedAt,
                City = cmd.City,
                Country = cmd.Country,
                DateOfBirth = cmd.DateOfBirth,
                FirstName = cmd.FirstName,
                LastName = cmd.LastName,
                PhoneNumber = cmd.PhoneNumber,
                Email = cmd.Email,
                State = cmd.State
            };
        }
    }
}
