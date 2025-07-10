using myWorks.Application.Interface.Repository;
using myWorks.Domain.myWorkDb;
using myWorks.Persistence.MyWorkDbContexts;

namespace myWorks.Persistence.Repository;

public class InterviewDetailRepository : Repository<InterviewDetail>, IInterviewDetailRepository
{
    public InterviewDetailRepository(MyWorkDbContext context, IResilientDbExecutor executor) : base(context, executor) { }    

}
