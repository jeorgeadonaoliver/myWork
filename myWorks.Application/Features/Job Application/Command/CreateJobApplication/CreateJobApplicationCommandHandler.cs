using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.Job_Application.Command.CreateJobApplication
{
    public class CreateJobApplicationCommandHandler : IRequestHandler<CreateJobApplicationCommand, Result<Guid>>
    {
        private readonly IJobApplicationRepository _repository;
        public CreateJobApplicationCommandHandler(IJobApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var mappedData = request.MapToJobApplication();
            var result = await _repository.AddAsync(mappedData, cancellationToken);

            if (result.IsFailed || result.Value == 0)
            {
                return Result.Fail($"Error on creating job application for applicant Id {request.ApplicantId}. Errors : {string.Join("; ", result.Errors)}");
            }

            return Result.Ok(request.ApplicationId);
        }
    }
}
