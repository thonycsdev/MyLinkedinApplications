using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;

namespace Repository.Ioc
{
    public static class RepositoryIoc
    {
        public static void AddRepositoryIoc(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        }
    }
}