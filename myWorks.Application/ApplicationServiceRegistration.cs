using FluentResults;
using Microsoft.Extensions.DependencyInjection;
using myWorks.Application.Features.ApplicantManagement.Command.CreateApplicant;
using myWorks.Application.Features.ApplicantManagement.Command.UpdateApplicant;
using myWorks.Application.Features.ApplicantManagement.Query.GetApplicant;
using myWorks.Application.Features.ApplicantManagement.Query.GetApplicantById;
using myWorks.Application.Features.InterviewMAnagement.Command.CreateInterviewDetail;
using myWorks.Application.Features.InterviewMAnagement.Command.UpdateInterviewDetail;
using myWorks.Application.Features.InterviewMAnagement.Query.GetInterviewDetailByApplicantionId;
using myWorks.Application.Features.Job_Application.Command.CreateJobApplication;
using myWorks.Application.Features.Job_Application.Command.UpdateJobApplication;
using myWorks.Application.Features.Job_Application.Query.GetJobApplication;
using myWorks.Application.Features.Job_Application.Query.GetJobApplicationByApplicant;
using myWorks.Application.Interface.Repository;

namespace myWorks.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetApplicantQuery, Result<IEnumerable<GetApplicantQueryDto>>>, GetApplicantQueryHandler>();
            services.AddScoped<IRequestHandler<GetApplicantByIdQuery, Result<GetApplicantByIdQueryDto>>, GetApplicantByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetInterviewDetailByApplicantionIdQuery, Result<GetInterviewDetailByApplicantionIdQueryDto>>, GetInterviewDetailByApplicantionIdQueryHandler>();

            services.AddScoped<IRequestHandler<CreateApplicantInformationCommand, Result<Guid>>, CreateApplicantInformationCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateApplicantCommand, Result<Guid>>, UpdateApplicantCommandHandler>();

            services.AddScoped<IRequestHandler<GetApplicantQuery, Result<IEnumerable<GetApplicantQueryDto>>>,GetApplicantQueryHandler>();
            services.AddScoped<IRequestHandler<GetApplicantByIdQuery, Result<GetApplicantByIdQueryDto>>, GetApplicantByIdQueryHandler>();

            services.AddScoped<IRequestHandler<CreateInterviewDetailCommand, Result<Guid>>, CreateInterviewDetailCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateInterviewDetailCommand, Result<Guid>>, UpdateInterviewDetailCommandHandler>();
            services.AddScoped<IRequestHandler<GetInterviewDetailByApplicantionIdQuery, Result<GetInterviewDetailByApplicantionIdQueryDto>>, GetInterviewDetailByApplicantionIdQueryHandler>();

            services.AddScoped<IRequestHandler<CreateJobApplicationCommand, Result<Guid>>, CreateJobApplicationCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateJobApplicationCommand, Result<Guid>>, UpdateJobApplicationCommandHandler>();
            services.AddScoped<IRequestHandler<GetJobApplicationQuery, Result<IEnumerable<GetJobApplicationQueryDto>>>, GetJobApplicationQueryHandler>();
            services.AddScoped<IRequestHandler<GetJobApplicationByApplicantIdQuery, Result<GetJobApplicationByApplicantIdQueryDto>>, GetJobApplicationByApplicantIdQueryHandler>();

            return services;
        }
    }
}
