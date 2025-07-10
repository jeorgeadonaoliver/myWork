using FluentResults;
using Microsoft.Extensions.DependencyInjection;
using myWorks.Application.Features.ApplicantManagement.Query.GetApplicant;
using myWorks.Application.Features.ApplicantManagement.Query.GetApplicantById;
using myWorks.Application.Features.InterviewMAnagement.Query.GetInterviewDetailByApplicantId;
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
            return services;
        }
    }
}
