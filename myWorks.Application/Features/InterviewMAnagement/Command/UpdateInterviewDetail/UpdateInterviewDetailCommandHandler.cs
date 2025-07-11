using FluentResults;
using Microsoft.Extensions.Logging;
using myWorks.Application.Interface.Repository;
using myWorks.Application.Interface.Service;

namespace myWorks.Application.Features.InterviewMAnagement.Command.UpdateInterviewDetail
{
    public class UpdateInterviewDetailCommandHandler : IRequestHandler<UpdateInterviewDetailCommand, Result<Guid>>
    {
        private readonly IInterviewDetailRepository _repository;
        private readonly ILogger<UpdateInterviewDetailCommandHandler> _logger;
        private readonly IBackgroundJobService _service;

        public UpdateInterviewDetailCommandHandler(IInterviewDetailRepository repository, ILogger<UpdateInterviewDetailCommandHandler> logger, IBackgroundJobService service)
        {
            _repository = repository;
            _logger = logger;
            _service = service;
        }
        public async Task<Result<Guid>> Handle(UpdateInterviewDetailCommand request, CancellationToken cancellationToken)
        {
            var mappedData = request.MapToInterviewDetail();
            var result = await _repository.UpdateAsync(mappedData, cancellationToken);
            if (result.Value == 0 || result.IsFailed) 
            {
                _logger.LogError($"Error on updating interview detail for applicantion Id {request.ApplicationId}. Errors : {string.Join("; ", result.Errors)}");
                return Result.Ok().WithError($"Error on updating interview detail for application Id {request.ApplicationId}. Errors : {string.Join("; ", result.Errors)}");
            }

            await SendEmail(request.Interviewer, request.InterviewDate, request.Notes);
            return Result.Ok(request.InterviewId);

        }

        private Task SendEmail(string email, DateTime dateTime, string notes) {
            try 
            {
                _service.Enqueue<IInterviewScheduleEmail>(x => x.Send(email, dateTime, notes));
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Error sending email for interview scheduling. Error {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
