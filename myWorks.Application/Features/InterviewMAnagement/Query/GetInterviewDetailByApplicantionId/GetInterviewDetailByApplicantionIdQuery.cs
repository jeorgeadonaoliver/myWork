using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.InterviewMAnagement.Query.GetInterviewDetailByApplicantionId;

public record GetInterviewDetailByApplicantionIdQuery(Guid id) : IRequest<Result<GetInterviewDetailByApplicantionIdQueryDto>>;    
