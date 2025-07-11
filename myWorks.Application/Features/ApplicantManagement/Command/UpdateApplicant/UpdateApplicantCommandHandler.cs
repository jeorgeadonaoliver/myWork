using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.ApplicantManagement.Command.UpdateApplicant
{
    public class UpdateApplicantCommandHandler : IRequestHandler<UpdateApplicantCommand, Result<Guid>>
    {
        private readonly IApplicantInformationRepository _repository;
        public UpdateApplicantCommandHandler(IApplicantInformationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var mappedData = request.MapToApplicationInformation();
            var result = await _repository.UpdateAsync(mappedData, cancellationToken);

            if(result.IsFailed)
            {
                return Result.Ok(request.ApplicantId)
                    .WithError($"Error on updating applicant id {request.ApplicantId} record!");
            }

            return Result.Ok(request.ApplicantId)
                .WithSuccess($"Applicant id {request.ApplicantId} record updated successfully!");

        }
    }
}
