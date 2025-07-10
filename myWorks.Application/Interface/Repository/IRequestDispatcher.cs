using FluentResults;

namespace myWorks.Application.Interface.Repository;

public interface IRequestDispatcher
{
    Task<Result<TResponse>> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
