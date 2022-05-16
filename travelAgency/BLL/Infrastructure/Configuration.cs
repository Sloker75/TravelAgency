using DLL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class Configuration
    {
        public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString, IdentityBuilder builder)
        {
            serviceCollection.AddDbContext<TravelAgencyContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("travelAgency")));

            builder.AddEntityFrameworkStores<TravelAgencyContext>();
        }
    }
}
