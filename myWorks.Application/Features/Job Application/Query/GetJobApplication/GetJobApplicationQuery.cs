using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.Job_Application.Query.GetJobApplication;

public record GetJobApplicationQuery : IRequest<Result<IEnumerable<GetJobApplicationQueryDto>>>{}
