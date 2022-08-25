using System.Threading.Tasks.Dataflow;
using Nest;
using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Voter.Queries;

public class VoterService : IVoterService
{
    private readonly IElasticClient _elasticClient;

    public VoterService(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient ?? throw new ArgumentNullException();
    }

    public async Task<List<DAL.Voter>> GetVoters()
    {
        var response = await _elasticClient.SearchAsync<DAL.Voter>(s => s
                            .Query(q => q
                                .MatchAll()
                            )
                        );
        
        return response.Documents.ToList();
    }   
}