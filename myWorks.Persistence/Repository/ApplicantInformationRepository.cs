using myWorks.Application.Interface.Repository;
using myWorks.Domain.myWorkDb;
using myWorks.Persistence.MyWorkDbContexts;

namespace myWorks.Persistence.Repository;

public class ApplicantInformationRepository : Repository<ApplicantInformation>, IApplicantInformationRepository
{
    public ApplicantInformationRepository(MyWorkDbContext context, IResilientDbExecutor executor) : base(context, executor) { }
}
