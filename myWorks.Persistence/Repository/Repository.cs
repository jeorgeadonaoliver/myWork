using FluentResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using myWorks.Application.Interface.Repository;
using Polly;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace myWorks.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly IResilientDbExecutor _executor;
        public Repository(DbContext context, IResilientDbExecutor executor)
        {
            _executor = executor;
            _context = context;
        }

        public async Task<Result<int>> AddAsync(T entity, CancellationToken cancellationToken)
        {

            //var retryPolicy = Policy.Handle<SqlException>().WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));

            return await _executor.ExecuteAsync<int>(async () => 
            {
                _context.Entry(entity).State = EntityState.Added;
                var rowsAffected = await _context.SaveChangesAsync(cancellationToken);

                return rowsAffected == 0 
                    ? Result.Fail("Failed to add entity.")
                    : Result.Ok(rowsAffected);
            }, cancellationToken);
        }

        public Task<Result<int>> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<T>>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _executor.ExecuteAsync<IEnumerable<T>>(async() => {
                var data = await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
                if (!data.Any())
                    return Result.Fail("No records found.");

                return Result.Ok<IEnumerable<T>>(data);
            },cancellationToken);
        }

        public async Task<Result<bool>> GetAnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _executor.ExecuteAsync<bool>(async() => {
                var data = await _context.Set<T>().AsNoTracking().AnyAsync(expression, cancellationToken);
                return data
                    ? Result.Ok(true)
                    : Result.Fail("No matching records found.");
            },cancellationToken);
        }

        public async Task<Result<T>> GetDetailAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _executor.ExecuteAsync<T>(async () => {
                var data = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
                if (data is not null)
                    return Result.Ok(data);

                return Result.Fail("No matching record found.");
            }, cancellationToken);
        }

        public async Task<Result<int>> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            return await _executor.ExecuteAsync<int>(async() => {
                _context.Update(entity).State = EntityState.Modified;
                var rowsAffected = await _context.SaveChangesAsync(cancellationToken);

                if (rowsAffected == 0)
                    return Result.Fail("Failed to update entity.");

                return Result.Ok(rowsAffected);
            }, cancellationToken);
        }
    }
}
