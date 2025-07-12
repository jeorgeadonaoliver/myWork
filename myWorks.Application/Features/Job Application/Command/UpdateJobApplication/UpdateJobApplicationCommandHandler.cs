using FluentResults;
using myWorks.Application.Interface.Repository;


namespace myWorks.Application.Features.Job_Application.Command.UpdateJobApplication;

public class UpdateJobApplicationCommandHandler : IRequestHandler<UpdateJobApplicationCommand, Result<Guid>>
{
    private readonly IJobApplicationRepository _repository;
    public UpdateJobApplicationCommandHandler(IJobApplicationRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<Guid>> Handle(UpdateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var mappedData = request.MapToJobApplication();
        var result = await _repository.UpdateAsync(mappedData, cancellationToken);
        if (result.Value == 0 || result.IsFailed)
        {
            return Result.Fail($"Error on updating job application for application Id {request.ApplicationId}. Errors : {string.Join("; ", result.Errors)}");
        }
        return Result.Ok(request.ApplicationId);
    }
}
