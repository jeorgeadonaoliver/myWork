namespace myWorks.Application.Interface.Service
{
    public interface IVerificationEmail
    {
        Task<string> Send(string email);
    }
}
