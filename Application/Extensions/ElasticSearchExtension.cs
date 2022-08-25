using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Extensions;
public static class ElasticSearchExtension
{
    private const string _defaultCategoryIndex = "Category";
    private const string _defaultCandidateIndex = "Candidate";
    private const string _defaultVoterIndex = "Voter";
    private const string _defaultVoteCastIndex = "VoteCast";
    public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
    {
        var url = configuration["ELKConfiguration:Uri"];
        var settings = new ConnectionSettings(new Uri(url))
                .PrettyJson()
                .DefaultIndex(_defaultCategoryIndex)
                .DefaultIndex(_defaultCandidateIndex)
                .DefaultIndex(_defaultVoterIndex)
                .DefaultIndex(_defaultVoteCastIndex);

        AddDefaultMappings(settings);

        var client = new ElasticClient(settings);
        services.AddSingleton<IElasticClient>(client);

        CreateIndex(client);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="settings"></param>
    private static void AddDefaultMappings(ConnectionSettings settings)
    {
        settings.DefaultMappingFor<DAL.CandidateCategory>(p => p.Ignore(x=>x.IsActive));   
    }

    private static void CreateIndex(IElasticClient client)
    {
        client.Indices.Create(_defaultCandidateIndex, i => i.Map<DAL.Candidate>(x => x.AutoMap()));
        client.Indices.Create(_defaultCategoryIndex, i => i.Map<DAL.CandidateCategory>(x => x.AutoMap()));
        client.Indices.Create(_defaultVoteCastIndex, i => i.Map<DAL.VoteCast>(x => x.AutoMap()));
        client.Indices.Create(_defaultVoterIndex, i => i.Map<DAL.Voter>(x => x.AutoMap()));
    } 
}