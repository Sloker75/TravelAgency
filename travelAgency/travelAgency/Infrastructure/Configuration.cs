using BLL.Services;
using Microsoft.AspNetCore.Identity;

namespace travelAgency.Infrastructure
{
    public class Configuration
    {
        public static void ConfigurationService(IdentityBuilder builder)
        {
            //Services
            builder.Services.AddTransient<TourService>();
            builder.Services.AddTransient<UserService>();
            builder.Services.AddTransient<ExcursionService>(); 
        }
    }
}
