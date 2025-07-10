using FluentResults;

namespace myWorks.Application.Interface.Repository
{
    public interface IResilientDbExecutor
    {
        Task<Result<T>> ExecuteAsync<T>(Func<Task<Result<T>>> action, CancellationToken cancellationToken);
    }
}
