using FluentResults;
using Microsoft.Extensions.Logging;
using myWorks.Application.Extension;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.ApplicantManagement.Query.GetApplicantById
{
    public record GetApplicantByIdQueryHandler : IRequestHandler<GetApplicantByIdQuery, Result<GetApplicantByIdQueryDto>>
    {
        private readonly IApplicantInformationRepository _repository;
        private readonly ILogger<GetApplicantByIdQueryHandler> _logger;
        public GetApplicantByIdQueryHandler(IApplicantInformationRepository repository, ILogger<GetApplicantByIdQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Result<GetApplicantByIdQueryDto>> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetDetailAsync(x => x.ApplicantId == request.id, cancellationToken);
            if (data.IsFailed)
            {
                var error = string.Join("; ", data.Errors.Select(e => e.Message));  
                _logger.LogError($"Failed to retrieve applicant with ID {request.id} : {error} ");
                return Result.Ok().WithError(error);
            }

            var mappedData = data.Value.MapToGetApplicantByIdQueryDto();
            return Result.Ok(mappedData);
        }
    }
}
