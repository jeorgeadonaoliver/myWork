using FluentResults;
using Microsoft.Extensions.Logging;
using myWorks.Application.Extension;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.ApplicantManagement.Query.GetApplicant;

public record GetApplicantQueryHandler : IRequestHandler<GetApplicantQuery, Result<IEnumerable<GetApplicantQueryDto>>>
{
    private readonly IApplicantInformationRepository _repository;
    private readonly ILogger<GetApplicantQueryHandler> _logger;
    public GetApplicantQueryHandler(IApplicantInformationRepository repository, ILogger<GetApplicantQueryHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<IEnumerable<GetApplicantQueryDto>>> Handle(GetApplicantQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetAllAsync(cancellationToken);
        if (data.IsFailed)
        {
            _logger.LogError($"Failed to retrieve applicants: {data.Errors}", string.Join("; ", data.Errors));
            return Result.Ok(Enumerable.Empty<GetApplicantQueryDto>()).WithError("Failed to retrieve applicants");
        }

        var mappedData = data.Value.Select(x => x.MapToGetApplicantQueryDto());
        return Result.Ok(mappedData);
    }
}
