using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myWorks.Application.Interface.Repository;
using myWorks.Persistence.MyWorkDbContexts;
using myWorks.Persistence.Repository;
using myWorks.Service.Request;

namespace myWorks.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection service, IConfiguration config) 
    {
        service.AddDbContext<MyWorkDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("MyWorkDbDocker"));
        });

        service.AddScoped<IResilientDbExecutor, ResilientDbExecutor>();
        service.AddScoped<IApplicantInformationRepository, ApplicantInformationRepository>();
        service.AddScoped<IInterviewDetailRepository, InterviewDetailRepository>();
        service.AddScoped<IJobApplicationRepository, JobApplicationRepository>();


        return service;
    }
}
