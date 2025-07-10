using FluentResults;
using Microsoft.Extensions.Logging;
using myWorks.Application.Extension;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.InterviewMAnagement.Query.GetInterviewDetailByApplicantId
{
    public class GetInterviewDetailByApplicantionIdQueryHandler : IRequestHandler<GetInterviewDetailByApplicantionIdQuery, Result<GetInterviewDetailByApplicantionIdQueryDto>>
    {
        private readonly IInterviewDetailRepository _repository;
        private readonly ILogger<GetInterviewDetailByApplicantionIdQueryHandler> _logger;
        public GetInterviewDetailByApplicantionIdQueryHandler(IInterviewDetailRepository repository, ILogger<GetInterviewDetailByApplicantionIdQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<GetInterviewDetailByApplicantionIdQueryDto>> Handle(GetInterviewDetailByApplicantionIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetDetailAsync(x => x.ApplicationId == request.id, cancellationToken);
            if (data.IsFailed)
            {
                _logger.LogError($"Failed to retrieve interview details for applicant ID {request.id} ");
                return Result.Ok(new GetInterviewDetailByApplicantionIdQueryDto()).WithError(string.Join("; ", data.Errors));
            }
            var mappedData = data.Value.MapToGetInterviewDetailByApplicantIdQueryDto();
            return Result.Ok(mappedData);
        }
    }
}
