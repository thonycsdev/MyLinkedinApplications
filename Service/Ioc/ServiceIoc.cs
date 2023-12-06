using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;

namespace Service.Ioc
{
    public static class ServiceIoc
    {
        public static void AddServiceIoc(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();
        }
    }
}