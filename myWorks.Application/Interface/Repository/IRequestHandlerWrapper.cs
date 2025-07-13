namespace myWorks.Application.Interface.Repository;

public interface IRequestHandlerWrapper
{
    Task<object> Handle(object request, CancellationToken cancellationToken);
}
