using Mail_Service_Training.Configuration;
using Mail_Service_Training.Services.Interfaces;
using Mail_Service_Training.Services;

namespace Mail_Service_Training.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddSingleton<IEmailService, EmailService>();
        }
    }
}
