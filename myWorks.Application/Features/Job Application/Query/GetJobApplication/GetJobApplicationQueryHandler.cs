using FluentResults;
using myWorks.Application.Extension;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.Job_Application.Query.GetJobApplication;

public class GetJobApplicationQueryHandler : IRequestHandler<GetJobApplicationQuery, Result<IEnumerable<GetJobApplicationQueryDto>>>
{
    private readonly IJobApplicationRepository _repository;
    public GetJobApplicationQueryHandler(IJobApplicationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<GetJobApplicationQueryDto>>> Handle(GetJobApplicationQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetAllAsync(cancellationToken);

        if (data.IsFailed) 
            return Result.Fail($"Error on getting job application. Errors : {string.Join("; ", data.Errors)}");

        if(!data.Value.Any())
            return Result.Fail("No job applications found.");

        var mappedData = data.Value.Select(x => x.MapToGetJobApplicationQueryDto());
        return Result.Ok(mappedData);
    }
}
