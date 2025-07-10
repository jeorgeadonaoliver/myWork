using FluentResults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using myWorks.Application.Interface.Repository;

namespace myWorks.Persistence.Repository
{
    public class RequestDispatcher : IRequestDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RequestDispatcher> _logger;

        public RequestDispatcher(IServiceProvider serviceProvider, ILogger<RequestDispatcher> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public async Task<Result<TResponse>> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            dynamic handler = _serviceProvider.GetRequiredService(handlerType);

            try
            {
                var response = await handler.Handle((dynamic)request, cancellationToken);

                _logger.LogInformation($"Request of type {request.GetType().Name} handled successfully.");
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error handling request of type {request.GetType().Name}.");
                return Result.Fail(ex.Message.ToString());
                //throw;
            }
        }
    }
}
