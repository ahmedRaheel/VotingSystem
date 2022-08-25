using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using VotingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Infrastructure.SeedData;
using VotingSystem.Infrastructure.Persistence.Interceptors;
using VotingSystem.Application.Common.Interfaces;
using VotingSystem.Infrastructure.Repositories;

namespace VotingSystem.Infrastructure.Extensions
{
    public static class InfrastructureServices
    {
         public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
         {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<VotingSystemContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<VotingSystemContextSeed>();
            services.AddTransient<ICandidateCategoryRepository, CandidateCategoryRepository>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<IVoterRepository, VoterRepository>();
            services.AddTransient<IVoteCastRepository, VoteCastRepository>();
            return services;
         }
    }  
}