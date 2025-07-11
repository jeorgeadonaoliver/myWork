namespace myWorks.Application.Interface.Service
{
    public interface IInterviewScheduleEmail
    {
        Task<string> Send(string email, DateTime interviewDate, string notes);
    }
}
