using FluentResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using myWorks.Application.Interface.Repository;
using Polly;

namespace myWorks.Persistence.Repository
{
    public class ResilientDbExecutor : IResilientDbExecutor
    {
        private readonly AsyncPolicy _retryPolicy;
        private readonly ILogger<ResilientDbExecutor> _logger;

        public ResilientDbExecutor(ILogger<ResilientDbExecutor> logger)
        {
            _logger = logger;
            _retryPolicy = Policy
                .Handle<SqlException>()
                .Or<DbUpdateException>() 
                .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));
        }

        public async Task<Result<T>> ExecuteAsync<T>(Func<Task<Result<T>>> action, CancellationToken cancellationToken)
        {
            try
            {
                return await _retryPolicy.ExecuteAsync(async ct => await action(), cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while connecting to the DB. List of Errors { ex.Message} ");
                return Result.Fail<T>($"Unexpected error: {ex.Message}");
            }
        }
    }
}
