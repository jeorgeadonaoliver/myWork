using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.ApplicantManagement.Command.CreateApplicant;

public class CreateApplicantInformationCommand : IRequest<Result<Guid>>
{
    public Guid ApplicantId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public DateTime CreatedAt { get; set; }

}
