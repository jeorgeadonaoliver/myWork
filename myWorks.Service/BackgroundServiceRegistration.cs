using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myWorks.Application.Interface.Service;
using myWorks.Service.Email;

namespace myWorks.Service
{
    public static class BackgroundServiceRegistration
    {
        public static IServiceCollection AddBackgroundService(this IServiceCollection service, IConfiguration config) 
        {
             service.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(config.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.FromSeconds(15),
                    DisableGlobalLocks = true
                })); 


            service.AddHangfireServer();

            service.AddSingleton<IBackgroundJobService, HangfireBackgroundJobService>();

            service.AddHttpClient<IVerificationEmail, VerificationEmail>()
                   .ConfigurePrimaryHttpMessageHandler(() => {
                       var handler = new HttpClientHandler();

                       // WARNING: ONLY FOR DEVELOPMENT/TESTING. DO NOT USE IN PRODUCTION.
                       handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                       return handler;
                   });

            return service;
        }

    }
}
