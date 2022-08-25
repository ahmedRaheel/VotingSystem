using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VotingSystem.Application.Candidate.Queries;
using VotingSystem.Application.CandidateCategory.Queries;
using VotingSystem.Application.Common.Behaviors;
using VotingSystem.Application.VoteCast.Queries;
using VotingSystem.Application.Voter.Queries;

namespace VotingSystem.Application.Extensions;

public static class ApplicationServiceExtension 
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddElasticSearch(configuration);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));      
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));     
        services.AddTransient<ICandidateCategoryService, CandidateCategoryService>();
        services.AddTransient<ICandidateService, CandidateService>();
        services.AddTransient<IVoterService, VoterService>();
        services.AddTransient<IVoteCastService, VoteCastService>();
        return services;
    }
}