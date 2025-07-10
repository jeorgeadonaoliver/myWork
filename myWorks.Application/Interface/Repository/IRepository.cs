using FluentResults;
using System.Linq.Expressions;

namespace myWorks.Application.Interface.Repository;

public interface IRepository<T> where T : class
{
    Task<Result<T>> GetDetailAsync(Expression<Func<T,bool>> expression, CancellationToken cancellationToken);

    Task<Result<bool>> GetAnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);

    Task<Result<IEnumerable<T>>> GetAllAsync(CancellationToken cancellationToken);

    Task<Result<int>> AddAsync(T entity, CancellationToken cancellationToken);

    Task<Result<int>> UpdateAsync(T entity, CancellationToken cancellationToken);

    Task<Result<int>> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
