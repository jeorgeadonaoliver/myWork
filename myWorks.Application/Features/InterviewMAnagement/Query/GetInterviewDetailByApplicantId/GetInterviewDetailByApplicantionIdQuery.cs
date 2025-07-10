using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.InterviewMAnagement.Query.GetInterviewDetailByApplicantId
{
    public record GetInterviewDetailByApplicantionIdQuery(Guid id) : IRequest<Result<GetInterviewDetailByApplicantionIdQueryDto>>;    
}
