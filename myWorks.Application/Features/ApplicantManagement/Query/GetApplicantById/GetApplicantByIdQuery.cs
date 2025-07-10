using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.ApplicantManagement.Query.GetApplicantById
{
    public record GetApplicantByIdQuery(Guid id) : IRequest<Result<GetApplicantByIdQueryDto>>;
}
