using HYPEDanceStudio.Domain.Interfaces;
using HYPEDanceStudio.Infrastructure.Persistence;
using HYPEDanceStudio.Infrastructure.Repositories;
using HYPEDanceStudio.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
        services.AddDbContext<PersonDbContext>(options=>options.UseSqlServer(
        configuration.GetConnectionString("Person")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<PersonDbContext>();

            services.AddScoped<PersonSeeder>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();

        }
        
    }
}
