using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.Job_Application.Command.CreateJobApplication
{
    public class CreateJobApplicationCommand : IRequest<Result<Guid>>
    {
        public Guid ApplicationId { get; set; }

        public Guid ApplicantId { get; set; }

        public string JobTitle { get; set; } = null!;

        public DateTime ApplicationDate { get; set; }

        public string Status { get; set; } = null!;

        public string? Resume { get; set; }
    }
}
