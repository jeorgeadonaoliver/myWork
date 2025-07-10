using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.ApplicantManagement.Query.GetApplicant
{
    public record GetApplicantQuery : IRequest<Result<IEnumerable<GetApplicantQueryDto>>>;
    
}
