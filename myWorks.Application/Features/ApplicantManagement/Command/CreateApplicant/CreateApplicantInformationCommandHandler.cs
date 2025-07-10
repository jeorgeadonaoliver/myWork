using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.ApplicantManagement.Command.CreateApplicant
{
    public class CreateApplicantInformationCommandHandler : IRequestHandler<CreateApplicantInformationCommand, Result<Guid>>
    {
        private readonly IApplicantInformationRepository _repository;
        public CreateApplicantInformationCommandHandler(IApplicantInformationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(CreateApplicantInformationCommand request, CancellationToken cancellationToken)
        {
            var mappedData = request.MapToApplicantInformation();
            var result = await _repository.AddAsync(mappedData,cancellationToken);

            return result.Value == 0 || result.IsFailed 
                ? Result.Ok(request.ApplicantId).WithError($"Error on creating applicant id {request.ApplicantId} record!") 
                : Result.Ok(request.ApplicantId);
        }
    }
}
