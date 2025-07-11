using FluentResults;
using Microsoft.Extensions.Logging;
using myWorks.Application.Interface.Repository;
using myWorks.Application.Interface.Service;

namespace myWorks.Application.Features.ApplicantManagement.Command.CreateApplicant
{
    public class CreateApplicantInformationCommandHandler : IRequestHandler<CreateApplicantInformationCommand, Result<Guid>>
    {
        private readonly IApplicantInformationRepository _repository;
        private readonly IBackgroundJobService _service;
        private readonly ILogger<CreateApplicantInformationCommandHandler> _logger;

        public CreateApplicantInformationCommandHandler(IApplicantInformationRepository repository, IBackgroundJobService service, ILogger<CreateApplicantInformationCommandHandler> logger)
        {
            _repository = repository;
            _service = service;
            _logger = logger;
        }

        public async Task<Result<Guid>> Handle(CreateApplicantInformationCommand request, CancellationToken cancellationToken)
        {
            var mappedData = request.MapToApplicantInformation();
            var result = await _repository.AddAsync(mappedData,cancellationToken);

            if (result.Value == 0 || result.IsFailed) {
                return Result.Ok(request.ApplicantId).WithError($"Error on creating applicant id {request.ApplicantId} record!");
            }

            await SendVerificationEmailAsync(request.Email);
            return Result.Ok(request.ApplicantId);
        }

        private Task SendVerificationEmailAsync(string email)
        {
            try {
                var response = _service.Enqueue<IVerificationEmail>(x => x.Send(email));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending verification email: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
