using myWorks.Application.Interface.Repository;
using myWorks.Domain.myWorkDb;
using myWorks.Persistence.MyWorkDbContexts;

namespace myWorks.Persistence.Repository;

public class JobApplicationRepository : Repository<JobApplication>, IJobApplicationRepository
{
    public JobApplicationRepository(MyWorkDbContext context, IResilientDbExecutor executor) : base(context, executor) { }
    
}
