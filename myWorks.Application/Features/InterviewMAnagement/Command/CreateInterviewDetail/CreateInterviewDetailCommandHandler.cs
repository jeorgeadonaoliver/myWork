using FluentResults;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application.Features.InterviewMAnagement.Command.CreateInterviewDetail;

public class CreateInterviewDetailCommandHandler : IRequestHandler<CreateInterviewDetailCommand, Result<Guid>>
{
    private readonly IInterviewDetailRepository _repository;
    public CreateInterviewDetailCommandHandler(IInterviewDetailRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<Guid>> Handle(CreateInterviewDetailCommand request, CancellationToken cancellationToken)
    {
        var mappedData = request.MapToInterviewDetail();
        var result = await _repository.AddAsync(mappedData, cancellationToken);
        if (result.IsFailed)
        {
            return Result.Ok(request.InterviewId).WithError(string.Join("; ", result.Errors));
        }
        return Result.Ok(request.InterviewId).WithSuccess($"Interview detail for application {request.ApplicationId} created successfully!");
    }
}
