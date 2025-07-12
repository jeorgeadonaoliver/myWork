using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.Job_Application.Query.GetJobApplicationByApplicant;

public record GetJobApplicationByApplicantIdQuery(Guid id) : IRequest<Result<GetJobApplicationByApplicantIdQueryDto>>;
