using FluentResults;
using myWorks.Application.Extension;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.Job_Application.Query.GetJobApplicationByApplicant;

public class GetJobApplicationByApplicantIdQueryHandler : IRequestHandler<GetJobApplicationByApplicantIdQuery, Result<GetJobApplicationByApplicantIdQueryDto>>
{
    private readonly IJobApplicationRepository _repository;
	public GetJobApplicationByApplicantIdQueryHandler(IJobApplicationRepository repository)
	{
		_repository = repository;
	}

    public async Task<Result<GetJobApplicationByApplicantIdQueryDto>> Handle(GetJobApplicationByApplicantIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetDetailAsync(x => x.ApplicantId == request.id, cancellationToken);

        if (data.IsFailed) 
            return Result.Fail($"Errors: {string.Join("; ", data.Errors)}");
        
        if(data.Value is null)
            return Result.Fail("No job application found for the given applicant ID.");

        var mappedData = data.Value.MapToGetJobApplicationByApplicantIdQueryDto();
        return Result.Ok(mappedData);
    }
}
