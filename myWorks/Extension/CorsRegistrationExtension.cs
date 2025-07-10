namespace myWorks.Extension
{
    public static class CorsRegistrationExtension
    {
        public static IServiceCollection AddCorsPolicyService(this IServiceCollection service) 
        {
            service.AddCors(option => 
            {
                option.AddPolicy(name: "EmailServiceApi", builder => {

                    builder.WithOrigins("http://localhost:64243/")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    //.AllowCredentials()
                });
            });

            return service;
        }
    }
}
