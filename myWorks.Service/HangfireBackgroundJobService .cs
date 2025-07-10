using Hangfire;
using myWorks.Application.Interface.Service;
using System.Linq.Expressions;

namespace myWorks.Service
{
    internal class HangfireBackgroundJobService : IBackgroundJobService
    {
        public string Enqueue<T>(Expression<Action<T>> methodCall)
        {
            return BackgroundJob.Enqueue(methodCall);
        }

        public string Schedule<T>(Expression<Action<T>> methodCall, TimeSpan delay)
        {
            return BackgroundJob.Enqueue(methodCall);
        }
    }
}
