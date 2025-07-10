

using System.Linq.Expressions;

namespace myWorks.Application.Interface.Service
{
    public interface IBackgroundJobService
    {
        string Enqueue<T>(Expression<Action<T>> methodCall);
        string Schedule<T>(Expression<Action<T>> methodCall, TimeSpan delay);
    }
}
